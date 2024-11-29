namespace ProjectEcommerceFruit.Dtos.Order
{
    public class ConfirmSendOrder
    {
        public int OrderId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
