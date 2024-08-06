using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Images { get; set; }
        public int Weight { get; set; } 
        public double Price { get; set; }
        public int Sold { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; } //สินค้าหมด
        public DateTime CreatedAt { get; set; }

        public int ProductGIId { get; set; }
        public ProductGI ProductGI { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        [JsonIgnore]
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
