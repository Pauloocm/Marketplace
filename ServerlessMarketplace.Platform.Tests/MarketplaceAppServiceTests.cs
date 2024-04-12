using NSubstitute;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Platform.Tests
{
    [TestFixture]
    public class MarketplaceAppServiceTests
    {
        private MarketplaceAppService appService;
        private ISqsService SqsServ;

        [SetUp]
        public void Setup()
        {
            SqsServ = Substitute.For<ISqsService>();
        }

        [Test]
        public void Add_Should_Throw_If_Command_Is_Invalid()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await appService.Add((AddProductCommand)null, Arg.Any<CancellationToken>()));
        }

    }
}
