using ProjectEcommerceFruit.Models;
using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Dtos.Order
{
    public class MyOrderToDriverHistoryRespone
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public int ShippingId { get; set; }
        public ShippingRespone Shipping { get; set; }
    }

    public class ShippingRespone 
    {
        public int Id { get; set; }
        public int ShippingFee { get; set; }
        public int ShippingStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        //public int OrderId { get; set; }
        //public OrderRespone Order { get; set; }
    }
}
