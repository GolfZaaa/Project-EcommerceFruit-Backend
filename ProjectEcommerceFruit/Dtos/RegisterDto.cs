namespace ProjectEcommerceFruit.Dtos
{
    public class RegisterDto : LoginDto
    {
        public required int RoleId { get; set; }
        public required string FullName { get; set; }
        public required int PhoneNumber { get; set; }
    }
}
