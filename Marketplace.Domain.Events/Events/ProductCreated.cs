using System.Text.Json;

namespace Marketplace.Domain.Events.Events
{
    public class ProductCreated : BaseEvent
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public override string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
