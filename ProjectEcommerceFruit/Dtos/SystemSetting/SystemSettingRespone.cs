namespace ProjectEcommerceFruit.Dtos.SystemSetting
{ 
    public class SystemSettingRespone
    {
        public int Id { get; set; }
        public string WebName { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }

        public ICollection<SlideShowRespone> SlideShows { get; set; } = new List<SlideShowRespone>();
    }
     
    public class SlideShowRespone
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public int SystemSettingId { get; set; } 
    }
}
