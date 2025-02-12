﻿namespace ProjectEcommerceFruit.Dtos.Address
{
    public class AddressRequest
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string PostCode { get; set; }
        public string Detail { get; set; }
        public bool IsUsed_Store { get; set; }
        public bool IsUsed { get; set; }
        public string? GPS { get; set; }
    }
}
