namespace ProjectEcommerceFruit.Models
{
    public class NEWS
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImageName { get; set; }
        public string Description { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Hidden { get; set; }
    }
}
