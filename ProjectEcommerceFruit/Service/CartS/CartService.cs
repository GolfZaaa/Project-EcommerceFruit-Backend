using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Cart;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UserS;

namespace ProjectEcommerceFruit.Service.CartS
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CartService(DataContext context, IAuthService authService,IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }
         
        public async Task<object> GetCartItemByUserOrderByStoreAsync()
        {
            var user = await _authService.GetUserByIdAsync();

            var cartItemsByStore = await _context.CartItems
            .Where(ci => ci.UserId == user.Id)
            .Select(ci => new
            {
                StoreId = ci.Product.ProductGI.StoreId,
                StoreName = ci.Product.ProductGI.Store.Name, // สมมติว่ามี Store.Name
                CartItemId = ci.Id,
                ProductName = ci.Product.ProductGI.Name, // สมมติว่ามี Name ใน ProductGI
                Weight = ci.Weight,
                Product = ci.Product,
                Price = ci.Product.Price
            })
            .GroupBy(item => new { item.StoreId, item.StoreName })
            .Select(group => new
            {
                StoreId = group.Key.StoreId,
                StoreName = group.Key.StoreName,
                Products = group.Select(item => new
                {
                    item.Product.Id,
                    item.Product.Images,
                    WeightInCartItem = item.Weight,
                    item.Product.Weight,
                    item.Product.Price,
                    item.Product.Sold,
                    item.Product.Detail,
                    item.Product.Status,
                    item.Product.CreatedAt,
                }).ToList()
            })
            .ToListAsync();

            return cartItemsByStore; 
        }

        public async Task<object> AddToCartAsync(AddToCartDto request)
        {
            var user = await _authService.GetUserByIdAsync();

            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id.Equals(request.ProductId));

            if (product is null) return "product is null";

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(
                x=>x.UserId.Equals(user.Id) && x.ProductId.Equals(product.Id));

            if(cartItem is null)
            {
                var newcartItem = new CartItem()
                {
                    UserId = user.Id,
                    ProductId = request.ProductId,
                    Weight = request.Weight,
                };

                _context.CartItems.Add(newcartItem);
            }else
            {
                if (request.Weight + cartItem.Weight > product.Weight)
                {
                    cartItem.Weight = product.Weight;
                }
                else
                {
                    cartItem.Weight += request.Weight;
                }
            }
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> RemoveToCartAsync(RemoveToCartDto request)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.Id.Equals(request.CartItemId));

            if (cartItem is null) return "cartItem is null";

            cartItem.Weight -= request.Weight;

            if (cartItem.Weight <= 0) _context.CartItems.Remove(cartItem);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
