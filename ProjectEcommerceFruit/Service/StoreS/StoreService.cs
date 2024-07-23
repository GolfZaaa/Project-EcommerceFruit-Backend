using AutoMapper;
using Azure.Core;
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

        public async Task<List<StoreRespone>> GetStoreAsync()
            => _mapper.Map<List<StoreRespone>>(await _context.Stores.Include(x=>x.User).ToListAsync());

        public async Task<StoreRespone> GetStoreByUserIdAsync()
            => _mapper.Map<StoreRespone>(
                await _context.Stores
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x => x.UserId.Equals(
                    _authService.GetUserByIdAsync().Result.Id)));

        //autherize หน้า controller ด้วย
        public async Task<Object> CreateUpdateStoreAsync(StoreRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            if (user.Stores.Count == 0)
            {
                var newStore = _mapper.Map<Store>(request);
                newStore.CreatedAt = DateTime.Now;

                user.Stores.Add(newStore);
            }else
            {
                _mapper.Map(request, user.Stores);
                _context.Stores.UpdateRange(user.Stores);
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
    }
}
