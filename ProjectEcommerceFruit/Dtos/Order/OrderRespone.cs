using ProjectEcommerceFruit.Dtos.Address;
using ProjectEcommerceFruit.Dtos.Product;
using ProjectEcommerceFruit.Models;
using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Dtos.Order
{
    public class OrderRespone
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string? PaymentImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string ShippingType { get; set; }
        public string Tag { get; set; }

        public int AddressId { get; set; }
        public AddressRespone Address { get; set; }

        public ICollection<OrderItemRespone> OrderItems { get; set; } = new List<OrderItemRespone>();
    }

    public class OrderItemRespone
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public ProductRespone Product { get; set; }
    }
}