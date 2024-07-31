using AutoMapper;
using Microsoft.EntityFrameworkCore; 
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Order;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.CartS;
using ProjectEcommerceFruit.Service.UserS;

namespace ProjectEcommerceFruit.Service.OrderS
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public OrderService(DataContext context,
            IAuthService authService,
            IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }
         
        public async Task<List<Order>> GetOrdersAsync()
            => await _context.Orders
                .Include(x=>x.Address)
                .Include(x=>x.OrderItems)
                    .ThenInclude(x=>x.Product).ToListAsync();

        public async Task<List<OrderRespone>> GetOrdersByUserAsync()
        {
            var user = await _authService.GetUserByIdAsync();

            var orders = await _context.Orders
                .Include(x => x.Address)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .Where(x=>x.Address.UserId.Equals(user.Id)).ToListAsync();

            return _mapper.Map<List<OrderRespone>>(orders);
        }

        public async Task<object> CreateUpdateOrderByIdAsync(OrderRequest request)
        {
            var order = await _context.Orders
                .Include(x=>x.OrderItems)
                .FirstOrDefaultAsync(x=>x.Id.Equals(request.Id));

            var user = await _authService.GetUserByIdAsync();

            if (order is null)
            {
                var newOrder = _mapper.Map<Order>(request);

                var address = user.Addresses.FirstOrDefault(x => x.IsUsed);

                if(address is null) return "address is null";

                newOrder.CreatedAt = DateTime.Now;
                newOrder.Address = address;

                var cartItems = await GetCartItemByUserOrderByStore(user.Id, request.StoreId);

                await _context.Orders.AddAsync(newOrder);

                if (cartItems.Count > 0) await _context.SaveChangesAsync();

                foreach (var item in cartItems)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = item.Id,
                        Weight = item.WeightInCartItem,
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
                _mapper.Map(request, order);
                _context.Orders.Update(order);
            }

            return await _context.SaveChangesAsync() > 0;
        }
          
        public async Task<object> ConfirmOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(x=>x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null) return "order is null";

            order.Status = 1;

            foreach (var item in order.OrderItems)
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                product.Sold += item.Weight;
                product.Weight -= item.Weight;
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
                    Weight = ci.Weight,
                    Product = ci.Product,
                    Price = ci.Product.Price
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
                        WeightInCartItem = item.Weight,
                        Weight = item.Product.Weight,
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

    }
}
