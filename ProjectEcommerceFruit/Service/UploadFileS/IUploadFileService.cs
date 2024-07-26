namespace ProjectEcommerceFruit.Service.UploadFileS
{
    public interface IUploadFileService
    {
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
