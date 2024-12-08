using System.Text.Json;

namespace Marketplace.Domain.Events.Events
{
    public class ProductDeleted : BaseEvent
    {
        public override string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
