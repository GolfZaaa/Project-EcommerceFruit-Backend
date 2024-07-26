namespace ProjectEcommerceFruit.Service.UploadFileS
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public UploadFileService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public bool IsUpload(IFormFileCollection formFiles)
        {
            return formFiles != null && formFiles?.Count > 0;
        }

        public string Validation(IFormFileCollection formFiles)
        {
            foreach (var file in formFiles)
            {
                if (!ValidationExtension(file.FileName))
                {
                    return "Invalid File Extension";
                }
                if (!ValidationSize(file.Length))
                {
                    return "The file is too large";
                }
            }
            return null;
        }

        public async Task<List<string>> UploadImages(IFormFileCollection formFiles, string pathName)
        {
            var listFileName = new List<string>();
            //จัดการเส้นทาง
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            var uploadPath = Path.Combine(wwwRootPath, pathName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            foreach (var formFile in formFiles)
            {
                string fileName = Guid.NewGuid().ToString() +
                Path.GetExtension(formFile.FileName);
                string fullName = Path.Combine(uploadPath, fileName);
                using (var stream = File.Create(fullName))
                {
                    await formFile.CopyToAsync(stream);
                }
                listFileName.Add(fileName);
            }

            return listFileName;
        }

        public Task DeleteFileImages(List<string> files, string pathName)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            foreach (var item in files)
            {
                var file = Path.Combine(pathName, item);
                var oldImagePath = Path.Combine(wwwRootPath, file);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            return Task.CompletedTask;
        }

        public bool ValidationExtension(string filename)
        {
            string[] permittedExtensions = { ".jpg", ".png", ".jpeg" }; // สามารถเพิ่มชื่อไฟล์ได้เลย
            string extension = Path.GetExtension(filename).ToLowerInvariant();

            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return false;
            };
            return true;
        }

        public bool ValidationSize(long fileSize) =>
            _configuration.GetValue<long>("FileSizeLimit") > fileSize;
    }
}
