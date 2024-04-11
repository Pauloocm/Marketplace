using Amazon.SQS.Model;

namespace ServerlessMarketplace.Platform.Infrastructure.Services
{
    public interface ISQSService
    {
        public Task<SendMessageResponse> SendMessageResponse(SendMessageRequest request, CancellationToken cancellationToken = default);
        public Task<SendMessageResponse> SendProductCreatedMessage(string data, CancellationToken cancellationToken = default);
    }
}
