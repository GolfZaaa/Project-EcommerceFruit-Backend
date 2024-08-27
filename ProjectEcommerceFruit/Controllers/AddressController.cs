using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.Address;
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
        public async Task<IActionResult> GetAddressByUserId()
         => Ok(await _addressService.GetAddressByUserIdAsync());

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetAddressgotoOrderByUserId()
            => Ok(await _addressService.GetAddressgotoOrderByUserIdAsync());

        [HttpGet("[action]"), Authorize]
        public async Task<IActionResult> GetAddressByStore()
            => Ok(await _addressService.GetAddressByStoreAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateAddress(AddressRequest request)
         => Ok(await _addressService.CreateUpdateAddressAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAddressById(int storeId)
         => Ok(await _addressService.RemoveAddressByIdAsync(storeId));

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> IsUsedAddress([FromForm] int addressId,[FromForm] bool storeormine)
         => Ok(await _addressService.IsUsedAddressAsync(addressId, storeormine));
    }
}
