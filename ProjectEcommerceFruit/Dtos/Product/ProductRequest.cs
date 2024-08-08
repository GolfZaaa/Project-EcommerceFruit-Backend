namespace ProjectEcommerceFruit.Dtos.Product
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public string? Images { get; set; }
        public double Weight { get; set; } 
        public int Quantity { get; set; } 
        public double Price { get; set; } 
        public string Detail { get; set; }

        public int ProductGIId { get; set; }
    }
}
