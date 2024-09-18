namespace ProjectEcommerceFruit.Models
{
    public class SystemSetting
    {
        public int Id { get; set; }
        public string WebName { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }

        public ICollection<SlideShow> SlideShows { get; set; } = new List<SlideShow>();
    }

    public class SlideShow
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }
        public bool IsUsed { get; set; }
        public bool Hidden { get; set; }
         
        public int SystemSettingId { get; set; }
        public SystemSetting SystemSetting { get; set; }
    }
}
 