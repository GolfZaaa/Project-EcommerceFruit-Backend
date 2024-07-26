using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UploadFileS;
using ProjectEcommerceFruit.Service.UserS;
using System.Net;

namespace ProjectEcommerceFruit.Service.ProductGiS
{
    public class ProductGIService : IProductGIService
    {
        private string _pathImage = "product-gi";

        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadFileService _uploadFileService;

        public ProductGIService(DataContext context,
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

        public async Task<List<ProductGIRespone>> GetProductGIAsync()
        {
            var userId = _authService.GetUserByIdAsync().Result.Id;

            var store = await _context.Stores.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

            return _mapper.Map<List<ProductGIRespone>>(await _context.ProductGIs.Where(x => x.StoreId.Equals(store.Id)).ToListAsync());
        }

        //autherize หน้า controller ด้วย
        public async Task<Object> CreateUpdateProductGIAsync(ProductGIRequest request)
        {
            (string errorMessges, List<string> imageNames) =
               await UploadImageAsync(request.FormFiles, _pathImage);

            if (!string.IsNullOrEmpty(errorMessges) || !string.IsNullOrEmpty(errorMessges)) return errorMessges;

            var user = await _authService.GetUserByIdAsync();

            if (user == null) return "user is null";

            var productGI = await _context.ProductGIs.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            var GI = _mapper.Map<ProductGI>(request);

            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id.Equals(user.Id));

            GI.StoreId = store.Id;

            if (productGI is null)
            {
                await _context.ProductGIs.AddAsync(GI);

                if (imageNames.Count() > 0)
                {
                    await _context.SaveChangesAsync();

                    var images = new List<Images>();
                    imageNames.ForEach(imageName =>
                    {
                        images.Add(new Images
                        {
                            ProductGIId = GI.Id,
                            ImageName = imageName
                        });
                    });

                    await _context.Images.AddRangeAsync(images);
                }
            }
            else
            {
                if (imageNames.Count() > 0)
                {
                    var images = new List<Images>();
                    imageNames.ForEach(imageName =>
                        images.Add(new Images
                        {
                            ProductGIId = GI.Id,
                            ImageName = imageName
                        }));

                    await _context.Images.AddRangeAsync(images);
                }

                _mapper.Map(request, productGI);
                _context.ProductGIs.Update(productGI);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveProductGIAsync(int productGIId)
        {
            var productGI = _context.ProductGIs.FirstOrDefault(x => x.Id.Equals(productGIId));

            if (productGI is not null)
            {
                _context.ProductGIs.Remove(productGI);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        //--------------------------------------category--------------------------------------------//

        public async Task<List<Category>> GetCategoriesAsync()
            => await _context.Categories.ToListAsync();

        public async Task<bool> CreateUpdateCategoryAsync(Category request)
        {
            var cate = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (cate is null)
            {
                await _context.Categories
                    .AddAsync(new Category { Id = request.Id, Name = request.Name });
            }
            else
            {
                cate.Name = request.Name;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveCategoryAsync(int categoryId)
        {
            var cate = _context.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (cate is null) return "category is null";

            _context.Categories.Remove(cate);

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
