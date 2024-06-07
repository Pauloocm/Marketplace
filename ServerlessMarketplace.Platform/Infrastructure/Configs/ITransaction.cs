namespace ServerlessMarketplace.Platform.Infrastructure.Configs
{
    public interface ITransaction : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
