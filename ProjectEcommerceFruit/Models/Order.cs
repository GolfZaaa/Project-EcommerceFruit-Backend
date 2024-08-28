namespace ProjectEcommerceFruit.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? OrderId { get; set; } 
        public string? PaymentImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string ShippingType { get; set; }
        public string? Tag { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
