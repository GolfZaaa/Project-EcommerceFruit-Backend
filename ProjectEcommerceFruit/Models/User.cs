using System.Text.Json.Serialization;

namespace ProjectEcommerceFruit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
    }
}
