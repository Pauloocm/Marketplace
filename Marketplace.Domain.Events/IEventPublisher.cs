using Marketplace.Domain.Events.Events;

namespace Marketplace.Domain.Events
{
    public interface IEventPublisher
    {
        Task Publish(BaseEvent baseEvent, CancellationToken cancellationToken);
    }
}
