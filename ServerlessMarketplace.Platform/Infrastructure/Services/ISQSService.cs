using Amazon.SQS.Model;

namespace ServerlessMarketplace.Platform.Infrastructure.Services
{
    public interface ISqsService
    {
        public Task<SendMessageResponse> SendProductCreatedMessage(string data, CancellationToken cancellationToken = default);
    }
}
