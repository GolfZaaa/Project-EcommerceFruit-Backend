﻿using Microsoft.AspNetCore.Authorization;
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
    }
}
