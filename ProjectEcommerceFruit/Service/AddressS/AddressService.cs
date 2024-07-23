using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UserS;

namespace ProjectEcommerceFruit.Service.AddressS
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AddressService(DataContext context, IAuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<List<Address>> GetAddressByUserIdAsync()
            => await _context.Addresses.Where(x=>x.Id.Equals(_authService.GetUserByIdAsync().Result.Id)).ToListAsync();

        public async Task<Object> CreateUpdateAddressAsync(StoreRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            if (user.Stores.Count == 0)
            {
                var newStore = _mapper.Map<Store>(request);
                newStore.CreatedAt = DateTime.Now;

                user.Stores.Add(newStore);
            }
            else
            {
                _mapper.Map(request, user.Stores);
                _context.Stores.UpdateRange(user.Stores);
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
