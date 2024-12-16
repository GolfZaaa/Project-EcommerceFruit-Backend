namespace ProjectEcommerceFruit.Dtos.Product
{
    public class FilterProducts
    {
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SortPrice { get; set; }
         
    }

    public class FilterProductsStore : FilterProducts
    {
        public int UserId { get; set; }
    }
}
