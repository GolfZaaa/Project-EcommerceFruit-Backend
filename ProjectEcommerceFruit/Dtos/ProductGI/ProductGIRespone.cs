using ProjectEcommerceFruit.Dtos.Store;
using ProjectEcommerceFruit.Models;

namespace ProjectEcommerceFruit.Dtos.ProductGI
{
    public class ProductGIRespone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int StoreId { get; set; }
        public StoreRespone Store { get; set; }

        public ICollection<ImageRespone> Images { get; set; } = new List<ImageRespone>();
    }

    public class ImageRespone
    {
        public int Id { get; set; }
        public string? ImageName { get; set; }

        public int ProductGIId { get; set; }
    }
}
