using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }

        public int RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        public ICollection<Store> Stores { get; set; } = new List<Store>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
