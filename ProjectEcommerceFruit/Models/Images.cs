namespace ProjectEcommerceFruit.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public int ProductGIId { get; set; }
        public ProductGI ProductGI { get; set; }
    }
}
