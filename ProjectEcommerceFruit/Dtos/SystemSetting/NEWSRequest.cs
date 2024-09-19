namespace ProjectEcommerceFruit.Dtos.SystemSetting
{
    public class NEWSRequest
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile? ImageName { get; set; }
        public string Description { get; set; } 
    }
}
