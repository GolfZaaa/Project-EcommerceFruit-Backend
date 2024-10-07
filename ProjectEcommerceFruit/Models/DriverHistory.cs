using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class DriverHistory
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusDriver { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }

    }

    public class Shipping
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public int ShippingStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public ICollection<DriverHistory> DriverHistories { get; set; } = new List<DriverHistory>();
    }
}
