using ProjectEcommerceFruit.Dtos.Cart;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.CartS
{
    public interface ICartService
    {
        Task<Object> GetCartItemByUserAsync();
        Task<Object> GetCartItemByUserOrderByStoreAsync();
        Task<Object> AddToCartAsync(AddToCartDto request);
        Task<Object> RemoveToCartAsync(RemoveToCartDto request);
        Task<Boolean> CheckExpireProductInCartAsync(int cartItemId);
    }
}
