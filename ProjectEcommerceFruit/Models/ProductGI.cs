namespace ProjectEcommerceFruit.Models
{
    public class ProductGI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } = true;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public ICollection<Images> Images { get; set; } = new List<Images>();
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
