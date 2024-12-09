using ProjectEcommerceFruit.Dtos.User;
using ProjectEcommerceFruit.Models;
using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Dtos.Order
{
    public class MyOrderToDriverHistoryRespone
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public DateTime CreatedAt { get; set; }
        public int StatusDriver { get; set; }

        public int UserId { get; set; }
        public UserRespone User { get; set; }

        public int ShippingId { get; set; } 
    }

    public class ShippingRespone 
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public int ShippingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? SendedOrderImage { get; set; }

        public ICollection<MyOrderToDriverHistoryRespone> DriverHistories { get; set; } = new List<MyOrderToDriverHistoryRespone>();

        //public int OrderId { get; set; }
        //public OrderRespone Order { get; set; }
    }
}
