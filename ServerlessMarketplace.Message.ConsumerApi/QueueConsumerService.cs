
using Amazon.SQS;
using Amazon.SQS.Model;
using ServerlessMarketplace.Message.ConsumerApi.Messages;
using System.Text.Json;

namespace ServerlessMarketplace.Message.ConsumerApi
{
    public class QueueConsumerService(IAmazonSQS sqs, ILogger<QueueConsumerService> iLogger) : BackgroundService
    {
        private readonly IAmazonSQS SqsClient = sqs ?? throw new ArgumentNullException(nameof(sqs));
        private readonly ILogger<QueueConsumerService> Logger = iLogger ?? throw new ArgumentNullException(nameof(iLogger));


        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting background message processor");

            var QueueUrlReponse = await SqsClient.GetQueueUrlAsync("Products", cancellationToken);

            try
            {
                var receiveMessageRequest = new ReceiveMessageRequest
                {
                    QueueUrl = QueueUrlReponse.QueueUrl,
                    MessageSystemAttributeNames = ["All"],
                    MessageAttributeNames = ["All"],
                    VisibilityTimeout = 80,
                    MaxNumberOfMessages = 3
                };

                while (!cancellationToken.IsCancellationRequested)
                {
                    var response = await SqsClient.ReceiveMessageAsync(receiveMessageRequest, cancellationToken);

                    foreach (var message in response.Messages)
                    {
                        var messageType = message.MessageAttributes["MessageType"].StringValue;

                        switch (messageType)
                        {
                            case nameof(ProductCreated):
                                Logger.LogInformation($"Consuming message: {nameof(ProductCreated)}");
                                var created = JsonSerializer.Deserialize<ProductCreated>(message.Body);
                                break;
                            case nameof(ProductUpdated):

                                Logger.LogInformation($"Consuming message: {nameof(ProductUpdated)}");
                                var updated = JsonSerializer.Deserialize<ProductCreated>(message.Body);
                                break;
                            case nameof(ProductDeleted):

                                Logger.LogInformation($"Consuming message: {nameof(ProductDeleted)}");
                                var deleted = JsonSerializer.Deserialize<ProductCreated>(message.Body);
                                break;
                            default:
                                Logger.LogWarning($"Unknown message type {messageType}");
                                break;
                        }

                        Logger.LogInformation("Deleting message with name: " + nameof(ProductCreated));
                        await SqsClient.DeleteMessageAsync(QueueUrlReponse.QueueUrl, message.ReceiptHandle, cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error consuming message" + ex.Message);
                throw;
            }
        }
    }
}
