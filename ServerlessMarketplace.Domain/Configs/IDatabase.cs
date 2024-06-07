namespace ServerlessMarketplace.Domain.Configs
{
    public interface IDatabase
    {
        Task<ITransaction> BeginTransactionAsync();
    }
}
