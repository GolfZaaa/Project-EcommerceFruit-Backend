using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEcommerceFruit.Data;
using ProjectEcommerceFruit.Dtos.SystemSetting;
using ProjectEcommerceFruit.Models;
using ProjectEcommerceFruit.Service.UploadFileS;

namespace ProjectEcommerceFruit.Service.SystemSettingS
{
    public class SystemSettingService : ISystemSettingService
    {
        private string _pathImage = "slide-show";
        private string _pathImageSS = "image-web";
        private string _pathImageNEWS = "image-news";

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public SystemSettingService(DataContext context, IMapper mapper, IUploadFileService uploadFileService)
        {
            _context = context;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }
        
        public async Task<List<SystemSettingRespone>> GetSystemSettingAsync()
            => _mapper.Map<List<SystemSettingRespone>>(await _context.SystemSettings.ToListAsync());

        public async Task<object> CreateUpdateSystemSettingAsync(SystemSettingRequest request)
        {
            string imageName = null;
            if (request.Image != null)
            {
                // อัปโหลดไฟล์แทนการส่งชื่อไฟล์ตรงๆ
                (string errorMessge, string uploadedImageName) =
                    await UploadImageAsync(request.Image, _pathImageSS);

                if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

                imageName = uploadedImageName;
            }

            var result = await _context.SystemSettings.FirstOrDefaultAsync(x=>x.Id == request.Id);

            if (result is null)
            {
                var mewSS = _mapper.Map<SystemSetting>(request);

                if (request.Image is not null)
                {
                    mewSS.Image = imageName;
                }

                await _context.AddAsync(mewSS);
            }
            else
            {
                if (request.Image is null)
                {
                    imageName = result.Image;
                }

                _mapper.Map(request, result);

                if (request.Image is not null)
                {
                    if (!string.IsNullOrEmpty(result.Image))
                    {
                        await _uploadFileService.DeleteFileImage(result.Image, _pathImageSS);
                    }
                }

                result.Image = imageName;

                _context.SystemSettings.Update(result);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> RemoveSystemSettingAsync(int SystemSettingId)
        {
            var result = await _context.SystemSettings.FirstOrDefaultAsync(_ => _.Id.Equals(SystemSettingId));

            if (result is null) return "systemSettingId is null";

            _context.SystemSettings.Remove(result);

            return await _context.SaveChangesAsync() > 0;
        }

        //-----------------------------------------------SlideShow---------------------------------------------//

        public async Task<List<SlideShow>> GetSlideShowAsync()
            => await _context.SlideShows.Where(x=> x.IsUsed && !x.Hidden).OrderByDescending(x=>x.Id).ToListAsync();

        public async Task<List<SlideShow>> GetSlideShowAdminAsync()
            => await _context.SlideShows.Where(x=> !x.Hidden).OrderByDescending(x=>x.Id).ToListAsync();
         
        public async Task<object> CreateUpdateSlideShowAsync(SlideShowRequest request)
        {
            string imageName = null;
            if (request.ImageName != null)
            {
                // อัปโหลดไฟล์แทนการส่งชื่อไฟล์ตรงๆ
                (string errorMessge, string uploadedImageName) =
                    await UploadImageAsync(request.ImageName, _pathImage);

                if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

                imageName = uploadedImageName;
            }

            var result = await _context.SlideShows.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
             
            if (result is null)
            {
                var slide = _mapper.Map<SlideShow>(request);

                slide.ImageName = imageName;
                slide.IsUsed = true;
                slide.Hidden = false;

                await _context.SlideShows.AddAsync(slide);
            }
            else
            {
                if (request.ImageName is null)
                {
                    imageName = result.ImageName;
                }

                _mapper.Map(request, result);

                if (request.ImageName is not null)
                {
                    if (!string.IsNullOrEmpty(result.ImageName))
                    {
                        await _uploadFileService.DeleteFileImage(result.ImageName, _pathImage);
                    } 
                }

                result.ImageName = imageName;

                _context.SlideShows.Update(result);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> IsUsedSlideShowAsync(int slideShowId)
        {
            var result = await _context.SlideShows.FirstOrDefaultAsync(x => x.Id.Equals(slideShowId));

            if (result is null) return "slideShow is null";

            result.IsUsed = !result.IsUsed;

            //if (result.ImageName != null)
            //{
            //    await _uploadFileService.DeleteFileImage(result.ImageName, "slideShow");
            //}

            //_context.SlideShows.Remove(result);

            return await _context.SaveChangesAsync() > 0 ? null! : 0;
        }

        public async Task<object> RemoveSlideShowAsync(int slideShowId)
        {
            var result = await _context.SlideShows.FirstOrDefaultAsync(x => x.Id.Equals(slideShowId));

            if (result is null) return "slideShow is null";

            result.Hidden = !result.Hidden;

            //if (result.ImageName != null)
            //{
            //    await _uploadFileService.DeleteFileImage(result.ImageName, "slideShow");
            //}

            //_context.SlideShows.Remove(result);

            return await _context.SaveChangesAsync() > 0 ? null! : 0;
        }

        //----------------------------------------------NEWS---------------------------------------------//

        public async Task<List<NEWS>> GetNEWSsAsync()
            => await _context.NEWSs.Where(x => x.IsUsed && !x.Hidden).OrderByDescending(x => x.Id).ToListAsync();

        public async Task<List<NEWS>> GetNEWSsAdminAsync()
            => await _context.NEWSs.Where(x => !x.Hidden).OrderByDescending(x => x.Id).ToListAsync();
        
        public async Task<object> CreateUpdateNEWSAsync(NEWSRequest request)
        {
            string imageName = null;
            if (request.ImageName != null)
            {
                // อัปโหลดไฟล์แทนการส่งชื่อไฟล์ตรงๆ
                (string errorMessge, string uploadedImageName) =
                    await UploadImageAsync(request.ImageName, _pathImageNEWS);

                if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

                imageName = uploadedImageName;
            }

            var result = await _context.NEWSs.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            
            if (result is null)
            {
                var news = _mapper.Map<NEWS>(request);

                news.ImageName = imageName;
                news.CreatedAt = DateTime.Now;
                news.IsUsed = true;
                news.Hidden = false;

                await _context.NEWSs.AddAsync(news);
            }
            else
            {
                if (request.ImageName is null)
                {
                    imageName = result.ImageName;
                }

                _mapper.Map(request, result);

                if (request.ImageName is not null)
                {
                    if (!string.IsNullOrEmpty(result.ImageName))
                    {
                        await _uploadFileService.DeleteFileImage(result.ImageName, _pathImageNEWS);
                    }
                }

                result.ImageName = imageName;

                _context.NEWSs.Update(result);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> IsUsedNEWSAsync(int newsId)
        {
            var result = await _context.NEWSs.FirstOrDefaultAsync(x => x.Id.Equals(newsId));

            if (result is null) return "NEWS is null";

            result.IsUsed = !result.IsUsed;
            
            return await _context.SaveChangesAsync() > 0 ? null! : 0;
        }

        public async Task<object> RemoveNEWSAsync(int newsId)
        {
            var result = await _context.NEWSs.FirstOrDefaultAsync(x => x.Id.Equals(newsId));

            if (result is null) return "NEWS is null";

            result.Hidden = !result.Hidden;
             
            return await _context.SaveChangesAsync() > 0 ? null! : 0;
        }

        public async Task<(string errorMessge, string imageNames)> UploadImageAsync(IFormFile formfile, string pathName)
        {
            var errorMessge = string.Empty;
            var imageName = string.Empty;

            if (_uploadFileService.IsUpload(formfile))
            {
                errorMessge = _uploadFileService.Validation(formfile);
                if (errorMessge is null)
                {
                    imageName = await _uploadFileService.UploadImage(formfile, pathName);
                }
            }

            return (errorMessge, imageName);
        }
        
    }
}
