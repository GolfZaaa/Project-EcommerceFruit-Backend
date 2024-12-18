using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UploadFileS;
using ProjectEcommerceFruit.Service.UserS;
using Stripe;
using System.Linq;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public class OrderService : IOrderService
    {
        private string _pathImage = "paymentImage";
        private string _pathSendedOrder = "sendedOrder";

        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadFileService _uploadFileService;
        private readonly IConfiguration _configuration;

        public OrderService(DataContext context,
            IAuthService authService,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment,
            IUploadFileService uploadFileService,
            IConfiguration configuration)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _uploadFileService = uploadFileService;
            _configuration = configuration;
        }

        public async Task<List<OrderRespone>> GetOrdersAsync()
            => _mapper.Map<List<OrderRespone>>(await _context.Orders
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
                .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories)
                .OrderByDescending(x => x.CreatedAt).ToListAsync());

        public async Task<OrderRespone> GetOrderByIdAsync(int orderId)
            => _mapper.Map<OrderRespone>(await _context.Orders
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
                .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories).FirstOrDefaultAsync(x => x.Id == orderId));

        public async Task<Order> GetOrderByIdLocalAsync(int orderId)
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
                .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories).FirstOrDefaultAsync(x => x.Id == orderId);

        public async Task<object> IWantToTakeOrdertoSendAsync(List<int> orderId)
        {
            foreach (var item in orderId)
            {
                var order = await GetOrderByIdLocalAsync(item);
                if (order is null) return "order is null";

                var user = await _authService.GetUserByIdAsync();
                if (user is null) return "user is null";

                var shipping = order.Shippings.FirstOrDefault();

                var driver = await _context.DriverHistories.FirstOrDefaultAsync(x => x.ShippingId == shipping.Id && x.UserId == user.Id && x.StatusDriver == 4);

                if (driver is null)
                {
                    var newDriver = new DriverHistory()
                    {
                        ShippingFee = 0,
                        CreatedAt = DateTime.Now,
                        UserId = user.Id,
                        ShippingId = shipping.Id,
                        StatusDriver = 4,
                    };

                    await _context.DriverHistories.AddAsync(newDriver);
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<OrderRespone>> GetMyOrderUserWantToTaketoSendAsync()
        {
            var user = await _authService.GetUserByIdAsync();

            var orders = _mapper.Map<List<OrderRespone>>(await _context.Orders
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
                .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories)
                                .ThenInclude(x => x.User)
                .Where(x => x.ConfirmReceipt == 0 &&
                    x.Shippings.Any(s =>
                        s.DriverHistories.Any(dh =>
                            dh.UserId == user.Id &&
                            dh.StatusDriver == 0) && s.DriverHistories.Count(x => x.StatusDriver == 4) != 0)).ToListAsync());

            return orders;
        }

        public async Task<object> ConfirmOrderToForwardAsync(int driverId, int shippingId, int shippingFee)
        {
            var user = await _authService.GetUserByIdAsync();

            var driver = await _context.DriverHistories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == driverId);

            var Mydriver = await _context.DriverHistories.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == user.Id && x.ShippingId == shippingId);

            if (driver is null || Mydriver is null) return driver is null ? "driver" : Mydriver is null ? "Mydriver" : "" + " is null";

            Mydriver.StatusDriver = 3;
            Mydriver.ShippingFee = Mydriver.ShippingFee - shippingFee;
            _context.DriverHistories.Update(Mydriver);

            driver.ShippingFee = shippingFee;
            driver.StatusDriver = 0;
            _context.DriverHistories.Update(driver);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TestOrderToReceipt>> GetOrdersWantToReceiptAsync()
            => await _context.Orders
                .Include(x => x.Address)
                .ThenInclude(x => x.User)
                .Include(x => x.OrderItems)
                    .ThenInclude(i => i.Product.ProductGI.Store.User.Addresses)
                .Include(x => x.OrderItems)
                    .ThenInclude(i => i.Product.ProductGI.Category)
                .Include(x => x.Shippings)
                    .ThenInclude(s => s.DriverHistories)
                .Where(x => x.Status == 1 && x.Tag == "จัดส่งผ่านผู้รับหิ้ว"
                    && x.ConfirmReceipt == 0
                    && x.Shippings.Any(s => s.ShippingStatus == 0)
                    && x.Shippings.All(s => s.DriverHistories.Count == 0))  // Optimize filtering here
                .Select(x => new TestOrderToReceipt
                {
                    Order = _mapper.Map<OrderRespone>(x),
                    Address = _mapper.Map<AddressRespone>(
                         //x.OrderItems.FirstOrDefault() != null &&
                         //x.OrderItems.FirstOrDefault().Product != null &&
                         //x.OrderItems.FirstOrDefault().Product.ProductGI != null &&
                         //x.OrderItems.FirstOrDefault().Product.ProductGI.Store != null &&
                         //x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User != null &&
                         //x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses != null
                         x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store))
                }).ToListAsync();
        //await _context.Orders
        //    .AsNoTracking()
        //    .Include(x => x.Address)
        //        .ThenInclude(x => x.User)
        //            .ThenInclude(x => x.Role)
        //    .Include(x => x.OrderItems)
        //        .ThenInclude(x => x.Product)
        //            .ThenInclude(x => x.ProductGI)
        //                .ThenInclude(x => x.Store)
        //                    .ThenInclude(x => x.User)
        //                        .ThenInclude(x => x.Addresses)
        //    .Include(x => x.OrderItems)
        //        .ThenInclude(x => x.Product)
        //            .ThenInclude(x => x.ProductGI)
        //                .ThenInclude(x => x.Category)
        //    .Include(x => x.Shippings)
        //        .ThenInclude(x => x.DriverHistories)
        //    .Where(x => x.Status == 1 && x.Tag == "จัดส่งผ่านผู้รับหิ้ว"
        //    && x.ConfirmReceipt == 0
        //    && x.Shippings.Any(x => x.ShippingStatus == 0)
        //    && x.Shippings.Any(x => x.DriverHistories.Count() == 0))
        //    .Select(x => new TestOrderToReceipt
        //    {
        //        Order = _mapper.Map<OrderRespone>(x),  // Map Order to OrderRespone
        //        Address = _mapper.Map<AddressRespone>(
        //            x.OrderItems.FirstOrDefault() != null &&
        //            x.OrderItems.FirstOrDefault().Product != null &&
        //            x.OrderItems.FirstOrDefault().Product.ProductGI != null &&
        //            x.OrderItems.FirstOrDefault().Product.ProductGI.Store != null &&
        //            x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User != null &&
        //            x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses != null
        //            ? x.OrderItems.FirstOrDefault().Product.ProductGI.Store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store)
        //            : null
        //        )
        //    }).ToListAsync();

        public async Task<List<TestOrderToReceipt>> SearchOrdersWantToReceiptAsync(string? district, string? subDistrict)
        {
            var result = await GetOrdersWantToReceiptAsync();

            var newOrder = new List<TestOrderToReceipt>();

            if (district != null && subDistrict != null)
            {
                newOrder = result.Where(x => x.Address.District.Contains(district)
                && x.Address.SubDistrict.Contains(subDistrict)).ToList();
            }
            else if (district != null)
            {
                newOrder = result.Where(x => x.Address.District.Contains(district)).ToList();
            }
            else if (subDistrict != null)
            {
                newOrder = result.Where(x => x.Address.SubDistrict.Contains(subDistrict)).ToList();
            }
            else
            {
                newOrder = result;
            }

            return newOrder;
        }

        public async Task<List<OrderRespone>> SearchOrderToSendByOrderIdAsync(string? orderId)
        {
            var result = await GetOrdersAsync();

            var user = await _authService.GetUserByIdAsync();

            if (orderId != null)
            {
                return result.Where(x => x.Shippings.Count() > 0
                    && x.OrderId == orderId
                    && x.ConfirmReceipt == 0
                    && x.Status == 1
                    && x.Shippings.Last().ShippingStatus != 1 && x.Shippings.Last().ShippingStatus != 2
                    && x.Shippings.Last().DriverHistories.All(x => x.UserId != user.Id)).ToList();
            }
            else
            {
                return new List<OrderRespone>();
            }
        }

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
                            .ThenInclude(x => x.Product)
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                                .ThenInclude(x => x.ProductGI)
                                    .ThenInclude(x => x.Category)
                        .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories)
                        .Include(x => x.Address)
                            .ThenInclude(x => x.User)
                        .OrderByDescending(x => x.CreatedAt)
                        .Where(x => x.Shippings.Any(s =>
                        s.DriverHistories.Any(dh => dh.UserId == user.Id && dh.StatusDriver != 4)))
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
                 .ThenInclude(x => x.DriverHistories)
                .Where(x => x.Address.UserId.Equals(user.Id))
                .OrderByDescending(x => x.CreatedAt).ToListAsync();

            return _mapper.Map<List<OrderRespone>>(orders);
        }

        public async Task<List<OrderRespone>> GetOrdersByStoreAsync(int storeId)
        {
            var orders = await _context.Orders
                .Include(x => x.Address)
                    .ThenInclude(x=>x.User)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                        .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Store)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                         .ThenInclude(x => x.ProductGI)
                            .ThenInclude(x => x.Category)
                 .Include(x => x.Shippings)
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
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            var user = await _authService.GetUserByIdAsync();

            var ss = await _context.SystemSettings.FirstOrDefaultAsync();

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

                foreach (var item in cartItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
                    if (product == null || product.Quantity < item.QuantityInCartItem)
                    {
                        _context.CartItems
                       .Remove(await _context.CartItems
                       .FirstOrDefaultAsync(x => x.ProductId == product.Id));
                        await _context.SaveChangesAsync();
                        return "Product Out of Stock";
                    }
                }
                //if (!cartItems.Any()){
                //    return "Product Out of Stock";
                //}

                await _context.Orders.AddAsync(newOrder);

                if (cartItems.Count > 0) await _context.SaveChangesAsync();

                newOrder.OrderId =
                    "KRU" + "-"
                    + user.Id + "-"
                    + request.StoreId + "-"
                    + newOrder.Id;

                foreach (var item in cartItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
                    var orderItem = new OrderItem
                    {
                        ProductId = item.Id,
                        Quantity = item.QuantityInCartItem,
                        Product = product
                    };

                    newOrder.OrderItems.Add(orderItem);

                    _context.CartItems
                        .Remove(await _context.CartItems
                        .FirstOrDefaultAsync(x => x.Id == item.CartItemId));
                }

                newOrder.Shippings.Add(new Models.Shipping()
                {
                    CreatedAt = DateTime.Now,
                    Order = newOrder,
                    ShippingFee = ss.ShippingCost,
                    ShippingStatus = 0,
                });
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
            await _context.SaveChangesAsync();

            if (request.PaymentMethod == Dtos.Order.PaymentMethod.CreditCard)
            {
                var intent = await CreatePaymentIntent(newOrder);
                if (!string.IsNullOrEmpty(intent.Id))
                {
                    newOrder.PaymentIntentId = intent.Id;
                    newOrder.ClientSecret = intent.ClientSecret;
                }
                newOrder.Status = 0;
            }
            await _context.SaveChangesAsync();

            var result = _context.Orders
       .Where(o => o.Id == newOrder.Id)
       .Select(o => new
       {
           o.Id,
           o.OrderId,
           o.CreatedAt,
           o.PaymentImage,
           o.Status,
           o.ClientSecret,
           Items = o.OrderItems.Select(i => new
           {
               i.ProductId,
               i.Quantity,
           }),
           Shipping = o.Shippings.Select(s => new
           {
               s.ShippingFee,
               s.ShippingStatus,
               s.CreatedAt
           })
       })
       .FirstOrDefault();

            //return newOrder.Id;
            return result;
        }

        private async Task<PaymentIntent> CreatePaymentIntent(Order order)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
            var service = new PaymentIntentService();
            var intent = new PaymentIntent();

            var shippingfee = await _context.SystemSettings.FirstOrDefaultAsync();

            var totalAmount = (long)order.OrderItems
               .Where(x => x.Product != null && x.Quantity > 0 && x.Product.Price > 0)
               .Sum(x => x.Product.Price * x.Quantity * 100);

            totalAmount += (long)(shippingfee.ShippingCost * 100);

            if (string.IsNullOrEmpty(order.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(totalAmount), 
                    Currency = "THB",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
            }

            return intent;
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


                //product.Quantity -= item.Quantity;
                product.Quantity = product.Quantity - item.Quantity < 0 ? 0 : product.Quantity - item.Quantity;
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

        public async Task<object> ChangeConfirmSendOrderAsync(ConfirmSendOrder request)
        {
            (string errorMessge, string imageName) =
               await UploadImageAsync(request.ImageFile, _pathSendedOrder);

            if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

            //foreach (var item in orderId)
            //{
            var order = await _context.Orders
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                        .Include(x => x.OrderItems)
                            .ThenInclude(x => x.Product)
                                .ThenInclude(x => x.ProductGI)
                                    .ThenInclude(x => x.Category)
                        .Include(x => x.Shippings)
                            .ThenInclude(x => x.DriverHistories)
                        .FirstOrDefaultAsync(x => x.Id == request.OrderId);

            if (order == null) return "order is null";

            order.Shippings.FirstOrDefault()!.ShippingStatus = 1;

            if (request.ImageFile is not null)
            {
                order.Shippings.FirstOrDefault()!.SendedOrderImage = imageName;
            } 

            var myDriver = order.Shippings.FirstOrDefault()!.DriverHistories.FirstOrDefault(x => x.StatusDriver == 0);

            myDriver.StatusDriver = 1;
            //}

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> CreateOrderToReceiptAsync(List<int> orderId)
        {
            var user = await _authService.GetUserByIdAsync();

            var ss = await _context.SystemSettings.FirstOrDefaultAsync();

            foreach (var item in orderId)
            {
                var order = await _context.Orders
                    .Include(x => x.Shippings).FirstOrDefaultAsync(x => x.Id == item);

                if (order == null) return "order is null";

                var shipping = order.Shippings.FirstOrDefault()!;

                //var newShipping = new Shipping()
                //{
                //    ShippingFee = ss.ShippingCost,
                //    ShippingStatus = 0,
                //    Order = order,
                //    CreatedAt = DateTime.Now,
                //};

                var driver = await _context.DriverHistories
                    .FirstOrDefaultAsync(x => x.ShippingId == shipping.Id && x.UserId == user.Id);

                if (driver is null)
                {
                    shipping.CreatedAt = DateTime.Now;

                    var newDriver = new DriverHistory()
                    {
                        ShippingFee = shipping!.ShippingFee,
                        CreatedAt = DateTime.Now,
                        User = user,
                        Shipping = shipping,
                    };

                    user.DriverHistories.Add(newDriver);
                }
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

        public async Task<dynamic> GetOrderItemByOrderIdAsync(int orderId)
        {
            var result = await _context.OrderItems.Where(x => x.OrderId == orderId).Include(x => x.Product).ThenInclude(x => x.ProductGI).ThenInclude(x => x.Category).ToListAsync();

            return result;
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