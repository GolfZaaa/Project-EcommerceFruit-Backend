namespace ProjectEcommerceFruit.Dtos.Order
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public IFormFile? PaymentImage { get; set; }
        public string? Tag { get; set; }

        public int StoreId { get; set; }
    }
}