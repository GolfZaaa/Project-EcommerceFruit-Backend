using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Service.AddressS;

namespace ProjectEcommerceFruit.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("[action]"), Authorize]
        public async Task<ActionResult> GetAddressByUserId()
         => Ok(await _addressService.GetAddressByUserIdAsync()); 
        
        [HttpPost("[action]"), Authorize]
        public async Task<ActionResult> CreateUpdateAddress(AddressRequest request)
         => Ok(await _addressService.CreateUpdateAddressAsync(request));

        [HttpDelete("[action]")]
        public async Task<ActionResult> RemoveAddressById(int storeId)
         => Ok(await _addressService.RemoveAddressByIdAsync(storeId));
    }
}
 