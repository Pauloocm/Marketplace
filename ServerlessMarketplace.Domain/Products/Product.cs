﻿namespace ServerlessMarketplace.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}