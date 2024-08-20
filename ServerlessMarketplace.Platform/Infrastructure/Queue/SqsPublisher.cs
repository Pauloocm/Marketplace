using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using ServerlessMarketplace.Platform.Message;
using System.Text.Json;

namespace ServerlessMarketplace.Platform.Infrastructure.Queue
{
    public class SqsPublisher(IAmazonSQS sqs, ILogger<SqsPublisher> iLogger) : ISqsPublisher
    {
        private readonly IAmazonSQS SqsClient = sqs ?? throw new ArgumentNullException(nameof(sqs));
        private readonly ILogger<SqsPublisher> Logger = iLogger ?? throw new ArgumentNullException(nameof(iLogger));

        public async Task PublishMessage(ProductCreated productCreated, CancellationToken cancellationToken = default)
        {
            var QueueUrlReponse = await SqsClient.GetQueueUrlAsync("Products", CancellationToken.None);
            var test = nameof(productCreated)[0].ToString().ToUpper();
            try
            {
                var sendMessageRequest = new SendMessageRequest
                {
                    QueueUrl = QueueUrlReponse.QueueUrl,
                    MessageBody = JsonSerializer.Serialize(productCreated),
                    MessageAttributes = new Dictionary<string, MessageAttributeValue>
                    {
                        {
                            "MessageType", new MessageAttributeValue
                            {
                                DataType = "String",
                                StringValue = nameof(ProductCreated)
                            }
                        }
                    }
                };

                await SqsClient.SendMessageAsync(sendMessageRequest, cancellationToken);

                Logger.LogInformation($"Message published {nameof(ProductCreated)}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Error publishing message {messageName}. Error message: {Errormessage}", nameof(ProductCreated), ex.Message);
                throw;
            }
        }
    }
}
