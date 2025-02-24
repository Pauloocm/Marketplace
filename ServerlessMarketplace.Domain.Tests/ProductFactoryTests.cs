using System.ComponentModel.DataAnnotations;
using ServerlessMarketplace.Domain.Products;

namespace ServerlessMarketplace.Domain.Tests;

[TestFixture]
public class ProductFactoryTests
{
    [Test]
    public void CreateShouldThrow_When_Values_Are_Invalid()
    {
        var ex = Assert.Throws<ValidationException>(()=>ProductFactory.Create("na", "description", 28, 2));

        var test = ex;
    }
}