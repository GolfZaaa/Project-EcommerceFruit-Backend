using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.User;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.CartS;
using ProjectEcommerceFruit.Service.UploadFileS;
using ProjectEcommerceFruit.Service.UserS;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public class OrderService : IOrderService
    {
        private string _pathImage = "paymentImage";

        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadFileService _uploadFileService;

        public OrderService(DataContext context,
            IAuthService authService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            IUploadFileService uploadFileService)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _uploadFileService = uploadFileService;
        }

        public async Task<List<OrderRespone>> GetOrdersAsync()
            => _mapper.Map<List<OrderRespone>>(await _context.Orders
                .Include(x => x.Address)
                    .ThenInclude(x => x.User)
                        .ThenInclude(x => x.Role)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories)
                .OrderByDescending(x => x.CreatedAt).ToListAsync());

        public async Task<List<TestOrderToReceipt>> GetOrdersWantToReceiptAsync()
            => await _context.Orders
                .Include(x => x.Address)
                    .ThenInclude(x => x.User)
                        .ThenInclude(x => x.Role)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Store)
                                .ThenInclude(x => x.User)
                                    .ThenInclude(x => x.Addresses)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Category)
                .Where(x => x.Status == 1 && x.Tag == "จัดส่งผ่านผู้รับหิ้ว" && x.ConfirmReceipt == 0 && x.Shippings.Count == 0)
                .Select(x => new TestOrderToReceipt
                {
                    Order = _mapper.Map<OrderRespone>(x),  // Map Order to OrderRespone
                    Address = _mapper.Map<AddressRespone>(
                        x.OrderItems.FirstOrDefault() != null &&
                        x.OrderItems.FirstOrDefault().Product != null &&
                        x.OrderItems.FirstOrDefault().Product.ProductGI != null &&
                        x.OrderItems.FirstOrDefault().Product.ProductGI.Store != null &&
                        x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User != null &&
                        x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses != null
                        ? x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store)
                        : null
                    )
                }).ToListAsync();

        //public async Task<List<MyOrderToDriverHistoryRespone>> GetMyOrderToSendAsync()
        //{ 
        //    var user = await _authService.GetUserByIdAsync();

        //    var order = await _context.DriverHistories
        //        .Include(x=>x.Shipping)
        //            .ThenInclude(x=>x.Order)
        //                .ThenInclude(x=>x.OrderItems).Where(x => x.UserId == user.Id).ToListAsync();

        //    return _mapper.Map<List<MyOrderToDriverHistoryRespone>>(order);
        //}

        public async Task<List<OrderRespone>> GetMyOrderToSendAsync()
        {
            var user = await _authService.GetUserByIdAsync();

            var order = await _context.Orders
                        .Include(x => x.OrderItems)
                            .ThenInclude(x=>x.Product)
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                                .ThenInclude(x => x.ProductGI)
                                    .ThenInclude(x => x.Category)
                        .Include(x=>x.Shippings)
                        .Where(x => x.Shippings.Any(s => s.DriverHistories.Any(dh => dh.UserId == user.Id)))
                        .ToListAsync();

            return _mapper.Map<List<OrderRespone>>(order);
        }

        public async Task<List<OrderRespone>> GetOrdersByUserAsync()
        {
            var user = await _authService.GetUserByIdAsync();

            var orders = await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Category)
                .Include(x => x.Shippings)
                .Where(x => x.Address.UserId.Equals(user.Id))
                .OrderByDescending(x => x.CreatedAt).ToListAsync();

            return _mapper.Map<List<OrderRespone>>(orders);
        }

        public async Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId)
        {
            var orders = await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Store)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                         .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Category)
                 .Where(x => x.OrderItems.Any(oi => oi.Product.ProductGI.StoreId == storeId))
                 .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return _mapper.Map<List<OrderRespone>>(orders);
        }

        public async Task<object> CreateUpdateOrderByIdAsync(OrderRequest request)
        {
            (string errorMessge, string imageName) =
               await UploadImageAsync(request.PaymentImage, _pathImage);

            if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            var user = await _authService.GetUserByIdAsync();

            var newOrder = _mapper.Map<Order>(request);

            if (order is null)
            {
                var address = user.Addresses.FirstOrDefault(x => x.IsUsed);

                if (address is null) return "address is null";

                newOrder.CreatedAt = DateTime.Now;
                newOrder.Address = address;
                newOrder.ShippingType = null;

                if (request.PaymentImage is not null)
                {
                    newOrder.PaymentImage = imageName;
                }

                var cartItems = await GetCartItemByUserOrderByStore(user.Id, request.StoreId);

                await _context.Orders.AddAsync(newOrder);

                if (cartItems.Count > 0) await _context.SaveChangesAsync();

                newOrder.OrderId =
                   "KRU" + "-"
                   + user.Id + "-"
                   + request.StoreId + "-"
                   + newOrder.Id;

                foreach (var item in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = item.Id,
                        Quantity = item.QuantityInCartItem,
                        Order = newOrder,
                    };

                    newOrder.OrderItems.Add(orderItem);

                    _context.CartItems
                        .Remove(await _context.CartItems
                        .FirstOrDefaultAsync(x => x.Id == item.CartItemId));
                }
            }
            else
            {
                if (request.PaymentImage is not null)
                {
                    if (order.PaymentImage is not null)
                    {
                        await _uploadFileService.DeleteFileImage(order.PaymentImage, _pathImage);
                    }

                    order.PaymentImage = imageName;
                }

                _mapper.Map(request, order);
                _context.Orders.Update(order);
            }

            return await _context.SaveChangesAsync() > 0 ? _mapper.Map<UserRespone>(user) : false;
        }

        public async Task<object> ConfirmOrderAsync(int orderId, string? trackingId, string? shippingType)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null) return "order is null";

            order.Status = 1;
            order.Tag = trackingId;
            order.ShippingType = shippingType;

            foreach (var item in order.OrderItems)
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                product.Sold += item.Quantity;
                product.Quantity -= item.Quantity;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> CancelOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null) return "order is null";

            order.Status = 2;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> ChangeConfirmReceiptOrderAsync(int orderId, int status)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null) return "order is null";

            order.ConfirmReceipt = status;

            return await _context.SaveChangesAsync() > 0;
        }
         
        public async Task<object> ChangeConfirmSendOrderAsync(List<int> orderId)
        {
            foreach (var item in orderId)
            {
                var order = await _context.Orders
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                                .ThenInclude(x => x.ProductGI)
                                    .ThenInclude(x => x.Category)
                        .Include(x => x.Shippings)
                        .FirstOrDefaultAsync(x => x.Id == item);

                if (order == null) return "order is null";

                order.Shippings.FirstOrDefault()!.ShippingStatus = 1;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> CreateOrderToReceiptAsync(List<int> orderId)
        {
            var user = await _authService.GetUserByIdAsync();

            var ss = await _context.SystemSettings.FirstOrDefaultAsync();

            foreach (var item in orderId)
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == item);
               

                if (order == null) return "order is null";

                var newShipping = new Shipping()
                {
                    ShippingFee = ss.ShippingCost,
                    ShippingStatus = 0,
                    Order = order,
                    CreatedAt = DateTime.Now,
                };

                var newDriver = new DriverHistory()
                {
                    ShippingFee = ss.ShippingCost,
                    CreatedAt = DateTime.Now,
                    User = user,
                    Shipping = newShipping,
                };

                user.DriverHistories.Add(newDriver);
            }
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ProductInfo>> GetCartItemByUserOrderByStore(int userId, int storeId)
        {
            var cartItemsByStore = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Select(ci => new
                {
                    StoreId = ci.Product.ProductGI.StoreId,
                    StoreName = ci.Product.ProductGI.Store.Name,
                    CartItemId = ci.Id,
                    ProductName = ci.Product.ProductGI.Name,
                    Quantity = ci.Quantity,
                    Product = ci.Product,
                    Price = ci.Product.Price,
                })
                .GroupBy(item => new { item.StoreId, item.StoreName })
                .Select(group => new
                {
                    StoreId = group.Key.StoreId,
                    StoreName = group.Key.StoreName,
                    Products = group.Select(item => new ProductInfo
                    {
                        Id = item.Product.Id,
                        CartItemId = item.CartItemId,
                        Images = item.Product.Images,
                        QuantityInCartItem = item.Quantity,
                        Weight = item.Product.Quantity, 
                        Price = item.Product.Price,
                        Sold = item.Product.Sold,
                        Detail = item.Product.Detail,
                        Status = item.Product.Status,
                        CreatedAt = item.Product.CreatedAt,
                    }).ToList()
                })
                .ToListAsync();

            var storeProducts = cartItemsByStore.FirstOrDefault(x => x.StoreId == storeId).Products;
            return storeProducts ?? new List<ProductInfo>();
        }

        //-------------------------------------another-------------------------------------//

        private async Task<string> ProcessFileUpload(IFormFile file)
        {
            string fileName = null;

            if (file != null && file.Length > 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                var uploadsPath = Path.Combine(wwwRootPath, _pathImage);

                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }

                fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(uploadsPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }

        public async Task<(string errorMessge, string imageNames)> UploadImageAsync(IFormFile formfile, string pathName)
        {
            var errorMessge = string.Empty;
            var imageName = string.Empty;

            if (_uploadFileService.IsUpload(formfile))
            {
                errorMessge = _uploadFileService.Validation(formfile);
                if (errorMessge is null)
                {
                    imageName = await _uploadFileService.UploadImage(formfile, pathName);
                }
            }

            return (errorMessge, imageName);
        }
    }
}