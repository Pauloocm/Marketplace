namespace Marketplace.Domain.Events.Events
{
    public class BaseEvent
    {
        protected BaseEvent()
        {
            CreatedAt = DateTime.Now;
        }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
