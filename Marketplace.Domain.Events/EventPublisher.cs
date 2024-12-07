using Amazon.CloudWatchLogs;
using Amazon.EventBridge;
using Amazon.EventBridge.Model;
using Marketplace.Domain.Events.Events;
using System.Text.Json;

namespace Marketplace.Domain.Events
{
    public class EventPublisher(IAmazonEventBridge amazonEventBridge) : IEventPublisher
    {
        private IAmazonEventBridge AmazonEventBridge { get; } = amazonEventBridge ?? throw new ArgumentNullException(nameof(amazonEventBridge));

        public async Task Publish(BaseEvent baseEvent, CancellationToken cancellationToken)
        {
            var cloudWatchLogger = new CloudWatchLogger(new AmazonCloudWatchLogsClient());

            ArgumentNullException.ThrowIfNull(baseEvent);

            var newEvent = JsonSerializer.Serialize(baseEvent);

            var test = baseEvent.GetType().Name;

            var request = new PutEventsRequest()
            {
                Entries =
                [
                    new PutEventsRequestEntry()
                    {
                        Source = "ProductApi",
                        DetailType = baseEvent.GetType().Name,
                        Detail = newEvent,
                        EventBusName = "Marketplace",
                        Time = DateTime.Now
                    }
                    ],
            };

            var response = await AmazonEventBridge.PutEventsAsync(request, cancellationToken);

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
                await cloudWatchLogger.LogEventAsync("Event published successfully.");
            }
        }
    }
}
