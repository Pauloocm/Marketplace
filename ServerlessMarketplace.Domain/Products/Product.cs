using ServerlessMarketplace.Domain.Categorys;
using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Domain.Products
{
    public class Product : BaseEntity, IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; private set; }

        private Category category = null!;

        public Category Category
        {
            get => category;
            set
            {
                category = value;
                if (value != null)
                    CategoryId = value.Id;
            }
        }

        public void Update(string name, string description, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length < 3)
                yield return new ValidationResult("Invalid description", [nameof(Description)]);
        }
    }
}