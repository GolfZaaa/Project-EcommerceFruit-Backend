using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Service.StoreS;

namespace ProjectEcommerceFruit.Controllers
{
    public class StoreController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        //ของ admin
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStore()
            => Ok(await _storeService.GetStoreAsync());

        [HttpGet("[action]"), Authorize]
        public async Task<ActionResult<StoreRespone>> GetStoreByUserId()
         => Ok(await _storeService.GetStoreByUserIdAsync());

        [HttpPost("[action]"), Authorize]
        public async Task<IActionResult> CreateUpdateStore(StoreRequest request)
         => Ok(await _storeService.CreateUpdateStoreAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveStoreById(int storeId)
         => Ok(await _storeService.RemoveStoreByIdAsync(storeId));

        [HttpGet("[action]")]
        public async Task<IActionResult> StoreAll()
        {
            var result = await _storeService.StoreAllAsync();
            return Ok(result);
        }

        //[HttpDelete("[action]"), Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _storeService.DeleteStoreAsync(id);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStoreProductUser(int userid)
        {
            var result = await _storeService.GetStoreProductUserAsync(userid);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStoreDetailByUserId(int userid)
        {
            var result = await _storeService.GetStoreDetailByUserIdAsync(userid);
            return Ok(result);
        }

    }
}
