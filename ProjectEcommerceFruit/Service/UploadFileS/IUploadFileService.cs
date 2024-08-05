 namespace ProjectEcommerceFruit.Service.UploadFileS
{
    public interface IUploadFileService
    {
        //--------------------------- รูปเดียว -----------------------------//
        bool IsUpload(IFormFile formFile);
        string Validation(IFormFile formFile);
        Task<string> UploadImage(IFormFile formFile, string pathName);
        Task DeleteFileImage(string file, string pathName);

        //---------------------------- หลายรูป ----------------------------//
        //ตรวจสอบมีการอัพโหลดไฟล์เข้ามาหรือไม่
        bool IsUpload(IFormFileCollection formFiles);
        //ตรวจสอบนามสกุลไฟล์หรือรูปแบบที่่ต้องการ
        string Validation(IFormFileCollection formFiles);
        //อัพโหลดและส่งรายชื่อไฟล์ออกมา
        Task<List<string>> UploadImages(IFormFileCollection formFiles, string pathName);
        Task DeleteFileImages(List<string> files, string pathName);
    }
}