﻿using System.ComponentModel.DataAnnotations;
using ServerlessMarketplace.Domain.Categorys;
using ServerlessMarketplace.Domain.Extensions;

namespace ServerlessMarketplace.Domain.Products
{
    public static class ProductFactory
    {
        public static Product Create(string name, string description, decimal price, int categoryId)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Category = Category.GetById(categoryId) ?? throw new ArgumentNullException("Category not found: " + categoryId)
            };

            product.EnsureIsValid();

            return product;
        }
    }
}
