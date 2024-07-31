namespace ProjectEcommerceFruit.Dtos.Order
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public string PaymentImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }
        public string ShippingType { get; set; }
        public string Tag { get; set; }

        public int StoreId { get; set; }
    }
}
