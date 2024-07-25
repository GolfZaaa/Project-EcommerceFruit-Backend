namespace ProjectEcommerceFruit.Dtos.ProductGI
{
    public class ProductGIRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }  

        public IFormFileCollection? FormFiles { get; set; }
    }
}
