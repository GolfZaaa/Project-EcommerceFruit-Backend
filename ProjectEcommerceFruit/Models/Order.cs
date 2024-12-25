using ProjectEcommerceFruit.Dtos.Order;

namespace ProjectEcommerceFruit.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? OrderId { get; set; } 
        public string? PaymentImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; } // 0 === กำลังรออนุมัติ, 1 === ยืนยันคำสั่งซื้อแล้ว, 2 === ยกเลิกคำสั่งซื้อแล้ว, 5 === คืนเงิน
        public string? ShippingType { get; set; }
        public string? Tag { get; set; }
        public int ConfirmReceipt { get; set; } // 0 === กำลังดำเนินการ, 1 === ได้รับพัสดุแล้ว, 2 === ไม่ได้รับพัสดุ, 3 === ผู้รับหิ้วเข้าพัสดุแล้ว

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        //public OrderStatus OrderStatus { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();

        public long GetTotalAmount()
        {
            return (long)OrderItems.Sum(x => x.Product.Price);
        }
    }
}
