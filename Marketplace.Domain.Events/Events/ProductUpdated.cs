using System.Text.Json;

namespace Marketplace.Domain.Events.Events
{
    public class ProductUpdated : BaseEvent
    {
        public override string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
