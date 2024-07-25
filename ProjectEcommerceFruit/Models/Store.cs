namespace ProjectEcommerceFruit.Models
{
    public class Store
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public bool Hidden { get; set; } = false;

        public ICollection<ProductGI> ProductGIs { get; set; } = new List<ProductGI>();
    } 
}
