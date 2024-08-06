using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Service.ProductS;

namespace ProjectEcommerceFruit.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProduct(int categoryId)
            => Ok(await _productService.GetProductAsync(categoryId));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductByStore(int storeId)
            => Ok(await _productService.GetProductByStoreAsync(storeId));

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUpdateProduct(ProductRequest request)
            => Ok(await _productService.CreateUpdateProductAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveProductById(int productId)
            => Ok(await _productService.RemoveProductByIdAsync(productId));
    }
}