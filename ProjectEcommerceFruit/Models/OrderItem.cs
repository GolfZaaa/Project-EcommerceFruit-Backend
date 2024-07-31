using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Weight { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
