namespace ServerlessMarketplace.Domain.Configs
{
    public interface ITransaction : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
