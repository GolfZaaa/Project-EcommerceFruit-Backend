namespace ProjectEcommerceFruit.Models
{
    public class SystemSetting
    {
        public int Id { get; set; }
        public string WebName { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public int ShippingCost { get; set; }
    }

    public class SlideShow
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public bool IsUsed { get; set; }
        public bool Hidden { get; set; } 
    }
}
 