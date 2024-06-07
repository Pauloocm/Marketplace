namespace ServerlessMarketplace.Domain
{
    public abstract class Entity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
