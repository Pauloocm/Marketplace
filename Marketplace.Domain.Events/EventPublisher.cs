using Amazon.CloudWatchLogs;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Marketplace.Domain.Events.Events;

namespace Marketplace.Domain.Events
{
    public class EventPublisher(IAmazonEventBridge amazonEventBridge) : IEventPublisher
    {
        private readonly CloudWatchLogger cloudWatchLogger = new(new AmazonCloudWatchLogsClient());

        private IAmazonEventBridge AmazonEventBridge { get; } = amazonEventBridge ?? throw new ArgumentNullException(nameof(amazonEventBridge));

        public async Task Publish(BaseEvent baseEvent, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(baseEvent);

            await cloudWatchLogger.LogEventAsync($"Starting publishing {baseEvent.GetType().Name} event for {baseEvent.Id}.");

            await cloudWatchLogger.LogEventAsync(baseEvent.LogEvent());

            var request = new PutEventsRequest()
            {
                Entries =
                [
                    new PutEventsRequestEntry()
                    {
                        Source = "ProductApi",
                        DetailType = baseEvent.GetType().Name,
                        Detail = baseEvent.ToJson(),
                        EventBusName = "Marketplace",
                        Time = DateTime.Now
                    }
                    ],
            };

            var response = await AmazonEventBridge.PutEventsAsync(request, cancellationToken);

            await ValidateResponse(response);
        }

        private async Task ValidateResponse(PutEventsResponse response)
        {
            if (response.FailedEntryCount > 0)
            {
                await cloudWatchLogger.LogEventAsync("Failed to publish some events.");
                foreach (var entry in response.Entries)
                {
                    if (!string.IsNullOrEmpty(entry.ErrorMessage))
                    {
                        await cloudWatchLogger.LogEventAsync($"Error: {entry.ErrorMessage}");
                    }
                }
            }
            else
            {
                await cloudWatchLogger.LogEventAsync($"Event published successfully.");
            }
        }
    }
}
