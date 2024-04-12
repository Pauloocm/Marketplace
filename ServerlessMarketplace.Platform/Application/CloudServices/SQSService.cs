using Amazon.SQS;
using Amazon.SQS.Model;
using ServerlessMarketplace.Platform.Infrastructure.Services;

namespace ServerlessMarketplace.Platform.Application.CloudServices
{
    public class SqsService : ISqsService
    {
        private static string QueueUrl => "https://sqs.us-west-2.amazonaws.com/307671859681/ProductsSqs";
        private readonly AmazonSQSClient client;

        public SqsService()
        {
            client = new AmazonSQSClient();
        }
 
        public async Task<SendMessageResponse> SendProductCreatedMessage(string data, CancellationToken cancellationToken = default)
        {
            var request = new SendMessageRequest($"{QueueUrl}", data);

            var response = await client.SendMessageAsync(request, cancellationToken);

            return response;
        }
    }
}
