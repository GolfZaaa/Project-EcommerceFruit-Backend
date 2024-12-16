using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Dtos.ProductGI;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UserS;

namespace ProjectEcommerceFruit.Service.StoreS
{
    public class StoreService : IStoreService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public StoreService(DataContext context, IAuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }

        //ของ admin
        public async Task<List<StoreRespone>> GetStoreAsync()
            => _mapper.Map<List<StoreRespone>>(await _context.Stores
                .Include(x => x.User)
                .Where(x => !x.Hidden).ToListAsync());

        public async Task<StoreRespone> GetStoreByUserIdAsync()
            => _mapper.Map<StoreRespone>(
                await _context.Stores
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => !x.Hidden && x.UserId.Equals(
                    _authService.GetUserByIdAsync().Result.Id)));

        //autherize หน้า controller ด้วย
        public async Task<Object> CreateUpdateStoreAsync(StoreRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            var store = await _context.Stores.FirstOrDefaultAsync(x => x.Id.Equals(request.ID));

            if (store is null)
            {
                var newStore = _mapper.Map<Store>(request);
                newStore.CreatedAt = DateTime.Now;

                user.Stores.Add(newStore);
            }
            else
            {
                _mapper.Map(request, store);
                _context.Stores.Update(store);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveStoreByIdAsync(int storeId)
        {
            var result = await _context.Stores.FirstOrDefaultAsync(x => x.Id.Equals(storeId));

            if (result is null) return "store is null";

            //_context.Stores.Remove(result);

            result.Hidden = !result.Hidden;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<dynamic> StoreAllAsync()
        {
            var result = await _context.Stores
                .Include(x => x.User)
                .Include(x => x.User)
                    .ThenInclude(x=>x.Addresses)
                .Select(store => new
                {
                    store.Id,
                    store.Name,
                    store.Description,
                    store.CreatedAt,
                    store.Hidden,
                    store.UserId,
                    User = new
                    {
                        store.User.Id,
                        store.User.FullName,
                    },
                    SubDistrict = store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store == true).SubDistrict,
                    District = store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store == true).District,
                    Province = store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store == true).Province,
                    PostCode = store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store == true).PostCode,
                    Detail = store.User.Addresses.FirstOrDefault(x => x.IsUsed_Store == true).Detail,
                })
                .ToListAsync();

            return result;
        }
        
        public async Task<object> DeleteStoreAsync(int id)
        {
            var result = await _context.Stores.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) { return "Don't Have Store"; }
            _context.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<object> GetStoreDetailByUserIdAsync(int userId)
        {
            var result = await _context.Stores.Include(x => x.User).Where(x => x.UserId == userId)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.CreatedAt,
                    x.UserId,
                    x.Hidden,
                    User = new
                    {
                        x.User.Id,
                        x.User.FullName,
                        x.User.PhoneNumber,
                        x.User.Hidden,
                        Address = x.User.Addresses.Select(a => new
                        {
                            a.Id,
                            a.Province,
                            a.District,
                            a.SubDistrict,
                            a.PostCode,
                            a.Detail,
                            a.IsUsed_Store,
                            a.IsUsed,
                            a.GPS,
                            a.CreatedAt,
                            a.UserId
                        })
                    }
                }).ToListAsync();
            if (result == null) { return "Don't Have Store"; }
            return result;
        }

        public async Task<List<ProductRespone>> GetStoreProductUserAsync(FilterProductsStore request)
        {
            // Query the products with related entities and initial filters
            var query = _context.Products
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Store)
                .Include(x => x.ProductGI)
                    .ThenInclude(x => x.Category)
                .Where(x => x.ProductGI.Store.UserId == request.UserId);

            // Apply filtering and sorting
            if (!string.IsNullOrEmpty(request.ProductName))
            {
                query = query.Where(x => x.ProductGI.Name.Contains(request.ProductName));
            }

            if (request.CategoryId > 0)
            {
                query = query.Where(x => x.ProductGI.Category.Id == request.CategoryId);
            }

            if (request.SortPrice == 1)
            {
                query = query.OrderBy(x => x.Price); // Ascending
            }
            else if (request.SortPrice == 2)
            {
                query = query.OrderByDescending(x => x.Price); // Descending
            }

            // Execute query and project results
            var products = await query.Select(x => new ProductRespone
            {
                Id = x.Id,
                Images = x.Images,
                Weight = x.Weight,
                Quantity = x.Quantity,
                Price = x.Price,
                Sold = x.Sold,
                Expire = x.Expire,
                Detail = x.Detail,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                ProductGI = new ProductGIRespone
                {
                    Id = x.ProductGI.Id,
                    Name = x.ProductGI.Name,
                    Description = x.ProductGI.Description,
                    Status = x.ProductGI.Status,
                    Category = new Category
                    {
                        Id = x.ProductGI.Category.Id,
                        Name = x.ProductGI.Category.Name
                    },
                    Store = new StoreRespone
                    {
                        Id = x.ProductGI.Store.Id,
                        Name = x.ProductGI.Store.Name,
                        Description = x.ProductGI.Store.Description,
                        UserId = x.ProductGI.Store.UserId
                    }
                }
            }).ToListAsync();

            // Return filtered and mapped products
            return products;
        }
         

        //public async Task<object> GetStoreProductUserAsync(int userid)
        //{
        //    var result = await _context.Products
        //        .Include(x => x.ProductGI)
        //            .ThenInclude(x => x.Store)
        //        .Include(x => x.ProductGI)
        //            .ThenInclude(x => x.Category)
        //        .Where(x => x.ProductGI.Store.UserId == userid)
        //        .Select(x => new
        //        {
        //            x.Id,
        //            x.Images,
        //            x.Weight,
        //            x.Quantity,
        //            x.Price,
        //            x.Sold,
        //            x.Expire,
        //            x.Detail,
        //            x.Status,
        //            x.CreatedAt,
        //            x.Hidden,
        //            ProductGI = new
        //            {
        //                x.ProductGI.Id,
        //                x.ProductGI.Name,
        //                x.ProductGI.Description,
        //                x.ProductGI.Status,
        //                Category = new
        //                {
        //                    x.ProductGI.Category.Id,
        //                    x.ProductGI.Category.Name
        //                },
        //                Store = new
        //                {
        //                    x.ProductGI.Store.Id,
        //                    x.ProductGI.Store.Name,
        //                    x.ProductGI.Store.Description,
        //                    x.ProductGI.Store.UserId,
        //                }
        //            }
        //        })
        //        .ToListAsync();

        //            return result;
        //        }



    }
}
