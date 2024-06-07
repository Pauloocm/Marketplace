namespace ServerlessMarketplace.Domain.Configs
{
    public class UnitOfWork(IDatabase _database) : IUnitOfWork
    {
        private readonly IDatabase database = _database;
        private ITransaction? currentTransaction;

        public async Task BeginTransactionAsync()
        {
            if (currentTransaction is not null)
                throw new InvalidOperationException("A transaction has already been started");

            currentTransaction = await database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (currentTransaction is null)
                throw new InvalidOperationException("A transaction has not been started.");

            try
            {
                await currentTransaction.CommitAsync();
                currentTransaction.Dispose();
                currentTransaction = null;
            }
            catch (Exception)
            {
                if (currentTransaction is not null)
                    await currentTransaction.RollbackAsync();
                throw;
            }
        }
    }
}
