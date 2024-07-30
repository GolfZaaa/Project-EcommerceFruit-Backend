using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Weight { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
