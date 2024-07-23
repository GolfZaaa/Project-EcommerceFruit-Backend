using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.Address;
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

        public async Task<List<AddressRespone>> GetAddressByUserIdAsync()
            => _mapper.Map<List<AddressRespone>>(await _context.Addresses.Where(x=>x.Id.Equals(_authService.GetUserByIdAsync().Result.Id)).ToListAsync());

        //autherize ใน controller ด้วย
        public async Task<Object> CreateUpdateAddressAsync(AddressRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (address is null)
            {
                var newAddress = _mapper.Map<Address>(request); 
                
                user.Addresses.Add(newAddress);
            }
            else
            {
                _mapper.Map(request, address);
                _context.Addresses.Update(address);
            }

            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<Object> RemoveAddressByIdAsync(int storeId)
        {
            var result = await _context.Addresses.FirstOrDefaultAsync(x => x.Id.Equals(storeId));

            if (result is null) return "address is null";

            _context.Addresses.Remove(result);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
