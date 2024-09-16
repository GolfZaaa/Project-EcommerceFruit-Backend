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
            => _mapper.Map<List<SystemSettingRespone>>(await _context.SystemSettings.Include(x=>x.SlideShows).ToListAsync());

        public async Task<object> CreateUpdateSystemSettingAsync(SystemSettingRequest request)
        {
            var result = await _context.SystemSettings.FirstOrDefaultAsync(x=>x.Id == request.Id);

            if (result is null)
            {
                await _context.AddAsync(_mapper.Map<SystemSetting>(request));
            }
            else
            {
                _mapper.Map(request, result);
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
            => await _context.SlideShows.ToListAsync();

        public async Task<object> CreateUpdateSlideShowAsync(SlideShowRequest request)
        {
            (string errorMessge, string imageName) =
              await UploadImageAsync(request.ImageName, _pathImage);

            if (!string.IsNullOrEmpty(errorMessge)) return errorMessge;

            var result = await _context.SlideShows.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
             
            if (result is null)
            {
                var slide = _mapper.Map<SlideShow>(request);

                slide.ImageName = imageName;

                await _context.SlideShows.AddAsync(slide);
            }
            else
            {
                _mapper.Map(request, result);

                if (request.ImageName is not null)
                {
                    if (!string.IsNullOrEmpty(result.ImageName))
                    {
                        await _uploadFileService.DeleteFileImage(result.ImageName, _pathImage);
                    }

                    result.ImageName = imageName;
                }

                _context.SlideShows.Update(result);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<object> RemoveSlideShowAsync(int slideShowId)
        {
            var result = await _context.SlideShows.FirstOrDefaultAsync(x => x.Id.Equals(slideShowId));

            if (result is null) return "slideShow is null";

            //if (result.ImageName != null)
            //{
            //    await _uploadFileService.DeleteFileImage(result.ImageName, "slideShow");
            //}

            _context.SlideShows.Remove(result);

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
