using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Cart;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.CartS;

namespace ProjectEcommerceFruit.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetCartItemByUser()
            => Ok(await _cartService.GetCartItemByUserAsync());

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetCartItemByUserOrderByStore()
            => Ok(await _cartService.GetCartItemByUserOrderByStoreAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> AddToCart(AddToCartDto request)
            => Ok(await _cartService.AddToCartAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveToCart(RemoveToCartDto request)
            => Ok(await _cartService.RemoveToCartAsync(request));
    }
}
