using ProjectEcommerceFruit.Dtos.SystemSetting;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Service.SystemSettingS
{
    public interface ISystemSettingService
    {
        Task<List<SystemSettingRespone>> GetSystemSettingAsync();
        Task<Object> CreateUpdateSystemSettingAsync(SystemSettingRequest request);
        Task<Object> RemoveSystemSettingAsync(int SystemSettingId);

        //-----------------------------------------------SlideShow---------------------------------------------//

        Task<List<SlideShow>> GetSlideShowAsync();
        Task<List<SlideShow>> GetSlideShowAdminAsync(); 
        Task<Object> CreateUpdateSlideShowAsync(SlideShowRequest request);
        Task<Object> IsUsedSlideShowAsync(int slideShowId);
        Task<Object> RemoveSlideShowAsync(int slideShowId);

        //-----------------------------------------------SlideShow---------------------------------------------//

        Task<List<NEWS>> GetNEWSsAsync();
        Task<List<NEWS>> GetNEWSsAdminAsync();
        Task<Object> CreateUpdateNEWSAsync(NEWSRequest request);
        Task<Object> IsUsedNEWSAsync(int newsId); 
        Task<Object> RemoveNEWSAsync(int newsId);
        Task<Object> GetNewsByIdAsync(int newsId);


    }
}  
