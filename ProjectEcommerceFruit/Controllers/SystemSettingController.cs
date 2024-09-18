using Microsoft.AspNetCore.Mvc;
using ProjectEcommerceFruit.Dtos.SystemSetting;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.SystemSettingS;

namespace ProjectEcommerceFruit.Controllers
{ 
    public class SystemSettingController : BaseController
    {
        private readonly ISystemSettingService _service;

        public SystemSettingController(ISystemSettingService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<SystemSetting>>> GetSystemSetting()
            => Ok(await _service.GetSystemSettingAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUpdateSystemSetting([FromForm] SystemSettingRequest request)
            => Ok(await _service.CreateUpdateSystemSettingAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveSystemSetting(int SystemSettingId)
            => Ok(await _service.RemoveSystemSettingAsync(SystemSettingId));

        //-----------------------------------------------SlideShow---------------------------------------------//

        [HttpGet("[action]")]
        public async Task<ActionResult<List<SlideShow>>> GetSlideShow()
            => Ok(await _service.GetSlideShowAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUpdateSlideShow([FromForm] SlideShowRequest request)
            => Ok(await _service.CreateUpdateSlideShowAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> IsUsedSlideShow(int slideShowId)
            => Ok(await _service.IsUsedSlideShowAsync(slideShowId));

        [HttpDelete("[action]")] 
        public async Task<IActionResult> RemoveSlideShow(int slideShowId)
            => Ok(await _service.RemoveSlideShowAsync(slideShowId));

    }
}
