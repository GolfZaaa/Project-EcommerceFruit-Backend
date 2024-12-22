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
            => _mapper.Map<List<AddressRespone>>(
                await _context.Addresses
                .Where(x=>x.UserId ==
                    _authService.GetUserByIdAsync().Result.Id).OrderByDescending(x=>x.CreatedAt).ToListAsync());

        public async Task<AddressRespone> GetAddressgotoOrderByUserIdAsync()  
            => _mapper.Map<AddressRespone>(
                await _context.Addresses
                .FirstOrDefaultAsync(x => x.UserId ==
                    _authService.GetUserByIdAsync().Result.Id && x.IsUsed == true));

        public async Task<AddressRespone> GetAddressByStoreAsync()
            => _mapper.Map<AddressRespone>(
                await _context.Addresses
                .FirstOrDefaultAsync(x => x.UserId.Equals(
                    _authService.GetUserByIdAsync().Result.Id) 
                && x.IsUsed_Store));

        //autherize ใน controller ด้วย 
        public async Task<Object> CreateUpdateAddressAsync(AddressRequest request)
        {
            var user = await _authService.GetUserByIdAsync();

            if (user is null) return "user is null";

            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

            if (address is null)
            {
                var newAddress = _mapper.Map<Address>(request);
                newAddress.CreatedAt = DateTime.Now;

                foreach (var item in user.Addresses)
                {
                    item.IsUsed = false;
                }

                user.Addresses.Add(newAddress);
            }
            else
            {
                if (address.IsUsed_Store)
                {
                    foreach (var item in user.Addresses)
                    {
                        item.IsUsed_Store = false;
                    }
                }

                _mapper.Map(request, address);
                _context.Addresses.Update(address);
            }

            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<Object> RemoveAddressByIdAsync(int addressId)
        {
            var result = await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(addressId));

            if (result is null) return "address is null";
            
            var adr = await _context.Addresses.FirstOrDefaultAsync(x=>x.UserId.Equals(result.UserId) && x.Id != result.Id);
            
            if(adr is not null)
            {
                if (result.IsUsed)
                {
                    adr.IsUsed = true;
                }

                if (result.IsUsed_Store)
                {
                    adr.IsUsed_Store = true;
                }
            }
            
            _context.Addresses.Remove(result);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsUsedAddressAsync(int addressId,bool storeormine)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id.Equals(addressId));

            var addresses =  
               await _context.Addresses
               .Where(x => x.UserId ==
                   _authService.GetUserByIdAsync().Result.Id).ToListAsync() ;

            if (address is null || addresses is null) return false;
             
            if (storeormine is true)
            { 
                foreach (var item in addresses)
                {
                    item.IsUsed_Store = false;
                }

                address.IsUsed_Store = true;
            }
            else
            {
                foreach (var item in addresses)
                {
                    item.IsUsed = false;
                }

                address.IsUsed = true;
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
