namespace ProjectEcommerceFruit.Dtos.SystemSetting
{
    public class SystemSettingRequest
    {
        public int Id { get; set; }
        public string WebName { get; set; }
        public IFormFile? Image { get; set; }
        public string Description { get; set; }
        public int ShippingCost { get; set; } = 40;
    }

    public class SlideShowRequest
    {
        public int Id { get; set; }
        public IFormFile? ImageName { get; set; } 
    }
}
