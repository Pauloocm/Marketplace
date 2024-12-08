using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

public class CloudWatchLogger(IAmazonCloudWatchLogs cloudWatchLogsClient)
{
    private readonly IAmazonCloudWatchLogs _cloudWatchLogsClient = cloudWatchLogsClient;
    private readonly string _logGroupName = "/aws/lambda/ProductApi";
    private readonly string _logStreamName = "ProductApi";

    public async Task LogEventAsync(string message)
    {
        // Ensure log group exists
        await EnsureLogGroupExistsAsync();

        // Ensure log stream exists
        await EnsureLogStreamExistsAsync();

        // Log the event
        var logEvent = new InputLogEvent
        {
            Message = message,
            Timestamp = DateTime.UtcNow
        };

        await _cloudWatchLogsClient.PutLogEventsAsync(new PutLogEventsRequest
        {
            LogGroupName = _logGroupName,
            LogStreamName = _logStreamName,
            LogEvents = [logEvent]
        });
    }

    private async Task EnsureLogGroupExistsAsync()
    {
        try
        {
            await _cloudWatchLogsClient.CreateLogGroupAsync(new CreateLogGroupRequest
            {
                LogGroupName = _logGroupName
            });
        }
        catch (ResourceAlreadyExistsException)
        {
            // Log group already exists; no action needed
        }
    }

    private async Task EnsureLogStreamExistsAsync()
    {
        try
        {
            await _cloudWatchLogsClient.CreateLogStreamAsync(new CreateLogStreamRequest
            {
                LogGroupName = _logGroupName,
                LogStreamName = _logStreamName
            });
        }
        catch (ResourceAlreadyExistsException)
        {
            // Log stream already exists; no action needed
        }
    }
}
