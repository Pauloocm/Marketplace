using ServerlessMarketplace.Platform.Message;

namespace ServerlessMarketplace.Platform.Infrastructure.Queue
{
    public interface ISqsPublisher
    {
        Task PublishMessage(ProductCreated productCreated, CancellationToken cancellationToken = default);
    }
}
