namespace ProjectEcommerceFruit.Dtos.SystemSetting
{
    public class SystemSettingRequest
    {
        public int Id { get; set; }
        public string WebName { get; set; }
        public string Description { get; set; }
    }

    public class SlideShowRequest
    {
        public int Id { get; set; }
        public IFormFile? ImageName { get; set; }

        public int SystemSettingId { get; set; } = 1;
    }
}
