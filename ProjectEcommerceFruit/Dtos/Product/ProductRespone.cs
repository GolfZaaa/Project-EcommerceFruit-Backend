using ProjectEcommerceFruit.Dtos.ProductGI;

namespace ProjectEcommerceFruit.Dtos.Product
{
    public class ProductRespone
    {
        public int Id { get; set; }
        public string? Images { get; set; }
        public double Weight { get; set; } 
        public int Quantity { get; set; } 
        public double Price { get; set; }
        public int Sold { get; set; }
        public DateTime Expire { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; } //สินค้าหมด
        public DateTime CreatedAt { get; set; }

        public int ProductGIId { get; set; }
        public ProductGIRespone ProductGI { get; set; }
    }
}
