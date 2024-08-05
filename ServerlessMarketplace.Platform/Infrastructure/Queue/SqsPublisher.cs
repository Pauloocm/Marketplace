using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;
using ServerlessMarketplace.Platform.Message;
using System.Text.Json;

namespace ServerlessMarketplace.Platform.Infrastructure.Queue
{
    public class SqsPublisher(IAmazonSQS sqs, ILogger<SqsPublisher> iLogger) : ISqsPublisher
    {
        private readonly IAmazonSQS SqsClient = sqs;
        private readonly ILogger<SqsPublisher> Logger = iLogger;

        public async Task PublishMessage(ProductCreated productCreated, CancellationToken cancellationToken = default)
        {
            var QueueUrlReponse = await SqsClient.GetQueueUrlAsync("Products", CancellationToken.None);

            try
            {
                var sendMessageRequest = new SendMessageRequest
                {
                    QueueUrl = QueueUrlReponse.QueueUrl,
                    MessageBody = JsonSerializer.Serialize(productCreated)
                };

                await SqsClient.SendMessageAsync(sendMessageRequest, cancellationToken);

                Logger.LogInformation("Message published", nameof(productCreated));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
