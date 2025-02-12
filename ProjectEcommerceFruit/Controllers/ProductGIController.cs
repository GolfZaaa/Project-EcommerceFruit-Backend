﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.ProductGiS;

namespace ProjectEcommerceFruit.Controllers
{
    public class ProductGIController : BaseController
    {
        private readonly IProductGIService _productGIService;

        public ProductGIController(IProductGIService productGIService)
        {
            _productGIService = productGIService;
        }

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetProductGI()
            => Ok(await _productGIService.GetProductGIAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateProductGI([FromForm] ProductGIRequest request)
            => Ok(await _productGIService.CreateUpdateProductGIAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveProductGI(int productGIId)
            => Ok(await _productGIService.RemoveProductGIAsync(productGIId));

        //--------------------------------------category--------------------------------------------//

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
         => Ok(await _productGIService.GetCategoriesAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUpdateCategory(Category request)
            => Ok(await _productGIService.CreateUpdateCategoryAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveCategoryAsync(int categoryId)
            => Ok(await _productGIService.RemoveCategoryAsync(categoryId));
    }
}
