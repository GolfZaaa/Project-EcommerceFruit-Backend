﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
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
                .Include(x=>x.User)
                .Where(x=>!x.Hidden).ToListAsync());

        public async Task<StoreRespone> GetStoreByUserIdAsync()
            => _mapper.Map<StoreRespone>(
                await _context.Stores
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x => !x.Hidden && x.UserId.Equals(
                    _authService.GetUserByIdAsync().Result.Id)));

        //autherize หน้า controller ด้วย
        public async Task<Object> CreateUpdateStoreAsync(StoreRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            var store = await _context.Stores.FirstOrDefaultAsync(x=>x.Id.Equals(request.ID));

            if (store is null)
            {
                var newStore = _mapper.Map<Store>(request);
                newStore.CreatedAt = DateTime.Now;

                user.Stores.Add(newStore);
            }else
            {
                _mapper.Map(request, store);
                _context.Stores.Update(store);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Object> RemoveStoreByIdAsync(int storeId)
        {
            var result = await _context.Stores.FirstOrDefaultAsync(x=>x.Id.Equals(storeId));

            if (result is null) return "store is null";

            //_context.Stores.Remove(result);

            result.Hidden = !result.Hidden;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<dynamic> StoreAllAsync()
        {
            var result = await _context.Stores
                .Include(x => x.User) 
                .Select(store => new
                {
                    store.Id,
                    store.Name,
                    store.Description,
                    store.Hidden,
                    store.CreatedAt,
                    User = new
                    {
                        store.User.Id,
                        store.User.FullName 
                    }
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

        public async Task<object> GetStoreProductUserAsync(int userid)
        {
            var result = await _context.Products
        .Include(x => x.ProductGI)
        .ThenInclude(x => x.Store).Include(x=>x.ProductGI).ThenInclude(x=>x.Category)
        .Where(x => x.ProductGI.Store.UserId == userid)
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
            ProductGI = new
            {
                x.ProductGI.Id,
                x.ProductGI.Name,
                x.ProductGI.Description,
                x.ProductGI.Status,
                Category = new
                {
                    x.ProductGI.Category.Id,
                    x.ProductGI.Category.Name
                },
                Store = new
                {
                    x.ProductGI.Store.Id,
                    x.ProductGI.Store.Name,
                    x.ProductGI.Store.Description,
                    x.ProductGI.Store.UserId,
                }
            }
        })
        .ToListAsync();

            return result;
        }



    }
}
