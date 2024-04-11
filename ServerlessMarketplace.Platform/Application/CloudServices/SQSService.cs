using Amazon.SQS;
using Amazon.SQS.Model;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Platform.Application.CloudServices
{
    public class SQSService : ISQSService
    {
        private readonly AmazonSQSClient client;

        public SQSService()
        {
            client = new AmazonSQSClient();
        }

        private readonly string QueueUrl = "https://sqs.us-west-2.amazonaws.com/307671859681/ProductsSqs";
        public Task<SendMessageResponse> SendMessageResponse(SendMessageRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<SendMessageResponse> SendProductCreatedMessage(string data, CancellationToken cancellationToken = default)
        {
            var request = new SendMessageRequest($"{QueueUrl}", data);

            var response = await client.SendMessageAsync(request, cancellationToken);

            return response;
        }
    }
}
