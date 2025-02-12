﻿using ProjectEcommerceFruit.Dtos.Store;

namespace ProjectEcommerceFruit.Dtos.User
{
    public class UserRespone
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public ICollection<StoreRespone> Stores { get; set; } = new List<StoreRespone>();
    }
}