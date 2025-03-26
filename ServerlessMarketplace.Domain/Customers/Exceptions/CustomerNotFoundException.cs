using ServerlessMarketplace.Resources;

namespace ServerlessMarketplace.Domain.Customers.Exceptions;

public class CustomerNotFoundException() : Exception(Messages.CustomerNotFoundException);