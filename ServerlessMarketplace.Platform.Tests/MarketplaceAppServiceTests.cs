using NSubstitute;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.Products;

namespace ServerlessMarketplace.Platform.Tests
{
    [TestFixture]
    public class MarketplaceAppServiceTests
    {
        private readonly MarketplaceAppService appService = null!;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_Should_Throw_If_Command_Is_Invalid()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await appService.Add((AddProductCommand)null!, Arg.Any<CancellationToken>()));
        }

    }
}
