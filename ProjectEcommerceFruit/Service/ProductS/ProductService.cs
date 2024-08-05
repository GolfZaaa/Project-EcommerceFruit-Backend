using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UploadFileS;
using ProjectEcommerceFruit.Service.UserS;
using System.Collections.Generic;

namespace ProjectEcommerceFruit.Service.ProductS
{
    public class ProductService : IProductService
    {
        private string _pathImage = "product";

        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadFileService _uploadFileService;

        public ProductService(DataContext context,
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

        public async Task<List<ProductRespone>> GetProductAsync(int categoryId)
        {
            var products = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(categoryId > 0
                ? products.Where(x => x.ProductGI.CategoryId == categoryId).ToList() : products.ToList());

            //var products = await _context.Products
            //    .Include(x => x.ProductGI)
            //        .ThenInclude(x => x.Category).ToListAsync();

            //return _mapper.Map<List<ProductRespone>>(products);
        }

        //public async Task<List<ProductRespone>> GetProductByCategoryAsync(int categoryId)
        //{
        //    var products = await _context.Products
        //        .Include(x => x.ProductGI)
        //            .ThenInclude(x => x.Category).ToListAsync();

        //    return _mapper.Map<List<ProductRespone>>(categoryId > 0 
        //        ? products.Where(x=>x.ProductGI.CategoryId == categoryId).ToList() : products.ToList());
        //}

        public async Task<List<ProductRespone>> GetProductByStoreAsync(int storeId)
        {
            var products = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category)
                .Where(x => x.ProductGI.StoreId.Equals(storeId)).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(products);
        }

        public async Task<object> CreateUpdateProductAsync(ProductRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (product is null)
            {
                var newProduct = _mapper.Map<Product>(request);

                await _context.Products.AddAsync(newProduct);
            }
            else
            {
                _mapper.Map(request, product);
                _context.Products.Update(product);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveProductByIdAsync(int productId)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(x => x.Id.Equals(productId));

            if (result is null) return "product is null";

            _context.Products.Remove(result);

            return await _context.SaveChangesAsync() > 0;
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

        public async Task<(string errorMessge, List<string> imageNames)> UploadImageAsync(IFormFileCollection formfiles, string pathName)
        {
            var errorMessge = string.Empty;
            var imageNames = new List<string>();

            if (_uploadFileService.IsUpload(formfiles))
            {
                errorMessge = _uploadFileService.Validation(formfiles);
                if (errorMessge is null)
                {
                    imageNames = await _uploadFileService.UploadImages(formfiles, pathName);
                }
            }

            return (errorMessge, imageNames);
        }
    }
}