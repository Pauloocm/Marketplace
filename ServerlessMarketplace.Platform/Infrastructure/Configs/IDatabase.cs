namespace ServerlessMarketplace.Platform.Infrastructure.Configs
{
    public interface IDatabase
    {
        Task<ITransaction> BeginTransactionAsync();
    }
}
