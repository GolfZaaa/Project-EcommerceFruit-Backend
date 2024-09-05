﻿namespace ProjectEcommerceFruit.Dtos.Product
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string? Images { get; set; }
        public int QuantityInCartItem { get; set; }
        public int CartItemId { get; set; }
        public int Weight { get; set; }  
        public int Quantity { get; set; }  
        public double Price { get; set; }
        public int Sold { get; set; }
        public DateTime Expire { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
