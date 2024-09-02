using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public int ProductGIId { get; set; }
        [JsonIgnore]
        public ProductGI ProductGI { get; set; }
    }
}
