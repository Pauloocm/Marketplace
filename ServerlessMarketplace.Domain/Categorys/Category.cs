using System.ComponentModel.DataAnnotations;

namespace ServerlessMarketplace.Domain.Categorys
{
    public class Category
    {
        private static readonly List<Category> Categories = [];

        public static readonly Category Hardware = new(1, "Hardware");
        public static readonly Category Eletrodomestico = new(2, "Eletrodomestico");
        public static readonly Category Periferico = new(3, "Periferico");
        public static readonly Category Tv = new(4, "Tv");
        public static readonly Category Smartphone = new(5, "Smartphone");

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Categories.Add(this);
        }

        public static List<Category> GetAll()
        {
            return Categories;
        }

        public static Category? GetById(int id)
        {
            return Categories.SingleOrDefault(c => c.Id == id);
        }

    }
}
