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
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

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
                    .ThenInclude(x=>x.Store)
                .Where(x => x.ProductGI.Name.Contains(productName) && x.ProductGI.Store.Hidden == false && !x.Hidden).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(products);
        }

        //sortPrice 1 === เรียงจากน้อยไปมาก, 2 === เรียงจากมากไปน้อย
        public async Task<List<ProductRespone>> GetFilterProductAsync(FilterProducts request)
        {
            var query = _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Store)
                        .ThenInclude(x=>x.User)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category)
                .Where(x => !x.Hidden && !x.ProductGI.Store.Hidden && x.Status && x.Quantity > 0); // Filter out hidden products and stores
             
            // Apply filters based on the provided parameters
            if (!string.IsNullOrEmpty(request.ProductName))
            {
                query = query.Where(x => x.ProductGI.Name.Contains(request.ProductName));
            }

            if (request.CategoryId > 0)
            {
                query = query.Where(x => x.ProductGI.CategoryId == request.CategoryId);
            }

            // Sort based on the sortPrice parameter
            if (request.SortPrice == 1)
            {
                query = query.OrderBy(x => x.Price); // Ascending น้อยไปมาก
            }
            else if (request.SortPrice == 2)
            {
                query = query.OrderByDescending(x => x.Price); // Descending มากไปน้อย
            }

            // Execute query and map the result to ProductRespone
            var products = await query.ToListAsync();
            return _mapper.Map<List<ProductRespone>>(products);
        }

        public async Task<List<ProductRespone>> GetProductAsync(int categoryId)
        {
            var products = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Images)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category)
                .Include(x=>x.ProductGI)
                    .ThenInclude(x=>x.Store)
                        .ThenInclude(x=>x.User).ToListAsync();

            return _mapper.Map<List<ProductRespone>>(categoryId > 0
                //? products.Where(x => x.ProductGI.CategoryId == categoryId && x.Status == true).ToList() : products.ToList());
                ? products.Where(x => x.ProductGI.CategoryId == categoryId && x.ProductGI.Store.Hidden == false && !x.Hidden).ToList() : products.Where(x=>x.ProductGI.Store.Hidden == false && !x.Hidden).ToList());

        }

        public async Task<object> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Images)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category)
                .Include(x=>x.ProductGI)
                    .ThenInclude(x=>x.Store)
                        .ThenInclude(x=>x.User)
                .Include(x=>x.ProductGI)
                    .ThenInclude(x=>x.Category)
                .Include(x=>x.ProductGI)
                    .ThenInclude(x=>x.Store)
                        .ThenInclude(x=>x.User)
                    .Select(x=> new
                    {
                        x.Id,
                        x.Images,
                        x.Weight,
                        x.Quantity,
                        x.Price,
                        x.Sold,
                        x.Expire,
                        x.Detail,
                        x.Status,
                        x.CreatedAt,
                        x.ProductGIId,
                        x.Hidden,
                        ProductGI = new
                        {
                            x.ProductGI.Id,
                            x.ProductGI.Name,
                            x.ProductGI.Description,
                            x.ProductGI.Status,
                            x.ProductGI.Images,
                            x.ProductGI.CategoryId,
                            x.ProductGI.StoreId,
                            Store = new
                            {
                                x.ProductGI.Store.Id,
                                x.ProductGI.Store.Name,
                                x.ProductGI.Store.Description,
                                x.ProductGI.Store.CreatedAt,
                                x.ProductGI.Store.UserId,
                                x.ProductGI.Store.Hidden,
                                User = new
                                {
                                    x.ProductGI.Store.User.Id,
                                    x.ProductGI.Store.User.FullName,
                                    x.ProductGI.Store.User.Username,
                                    x.ProductGI.Store.User.PhoneNumber,
                                    x.ProductGI.Store.User.Hidden,
                                }
                            },
                            Category = new
                            {
                                x.ProductGI.Category.Id,
                                x.ProductGI.Category.Name,
                            }
                        }
                    })
                    //.FirstOrDefaultAsync(x => x.Id == productId && x.Status == true);
                    //.FirstOrDefaultAsync(x => x.Id == productId && x.ProductGI.Store.Hidden == false && !x.Hidden);
                    .FirstOrDefaultAsync(x => x.Id == productId);

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
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Store)
                .Where(x => x.ProductGI.StoreId.Equals(storeId) && x.ProductGI.Store.Hidden == false && !x.Hidden).ToListAsync();

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

        public async Task<Object> IsUsedProductByIdAsync(int productId)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(x => x.Id.Equals(productId));

            if (result is null) return "product is null";

            result.Status = !result.Status;

            return await _context.SaveChangesAsync() > 0;
        }
         
        public async Task<Object> RemoveProductByIdAsync(int productId)
        {
            var result = await _context.Products
                .FirstOrDefaultAsync(x => x.Id.Equals(productId));

            if (result is null) return "product is null";

            result.Hidden = !result.Hidden;

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
            var result = await _context.Products
                .Include(x => x.Images)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Store)
                .Where(x=>x.ProductGI.Store.Hidden == false).ToListAsync();

            return result;
        }


        public async Task<Object> AddStockProductAsync(AddStockProductDto dto)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == dto.ProductId);
            if (result is null) return "Not Found Product";
            result.Quantity = dto.Quantity;
            return await _context.SaveChangesAsync() > 0;
        }


    }
}