namespace Marketplace.Domain.Events.Events
{
    public class ProductCreated : BaseEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
