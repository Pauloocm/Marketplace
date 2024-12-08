namespace Marketplace.Domain.Events.Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent()
        {
            CreatedAt = DateTime.Now;
        }

        public required Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public abstract string ToJson();
        public virtual string LogEvent()
        {
            string logg = "Event properties: \n";

            foreach (var propery in this.GetType().GetProperties())
            {
                logg += $"{propery.Name}: ";
                logg += $"{propery.GetValue(this)} ";
                logg += "\n";
            }

            return logg;
        }
    }
}
