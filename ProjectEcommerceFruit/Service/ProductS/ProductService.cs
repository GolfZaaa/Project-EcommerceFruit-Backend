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

        public async Task<List<ProductRespone>> SearchProductAsync(string productName)
        {
            var products = await _context.Products
                .Include(x => x.ProductGI)
                .Where(x => x.ProductGI.Name.Contains(productName)).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(products);
        }
        
        public async Task<List<ProductRespone>> GetProductAsync(int categoryId)
        {
            var products = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Images)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(categoryId > 0
                ? products.Where(x => x.ProductGI.CategoryId == categoryId && x.Status == true).ToList() : products.ToList());

            //var products = await _context.Products
            //    .Include(x => x.ProductGI)
            //        .ThenInclude(x => x.Category).ToListAsync();

            //return _mapper.Map<List<ProductRespone>>(products);
        }

        public async Task<object> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Images)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == productId && x.Status == true);
            
            if (product == null)
            {
                return null;
            }

            return product;
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
            (string errorMessge, string imageName) =
              await UploadImageAsync(request.Images, _pathImage);

            if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            var newProduct = _mapper.Map<Product>(request);

            if (product is null)
            {
                newProduct.CreatedAt = DateTime.Now;
                newProduct.Sold = 0;
                newProduct.Status = true;

                if (request.Images is not null)
                {
                    newProduct.Images = imageName;
                }

                await _context.Products.AddAsync(newProduct);
            }
            else
            {
                _mapper.Map(request, product);

                if (request.Images is not null)
                {
                    if (!string.IsNullOrEmpty(product.Images))
                    {
                        await _uploadFileService.DeleteFileImage(product.Images, _pathImage);
                    }

                    product.Images = imageName;
                }

                _context.Products.Update(product);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveProductByIdAsync(int productId)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(x => x.Id.Equals(productId));

            if (result is null) return "product is null";

            result.Status = !result.Status;

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

        public async Task<dynamic> ProductAllAsync()
        {
            var result = await _context.Products.Include(x=>x.Images).ToListAsync();
            return result;
        }


    }
}