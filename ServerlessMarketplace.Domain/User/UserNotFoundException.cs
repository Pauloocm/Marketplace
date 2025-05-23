using ServerlessMarketplace.Resources;

namespace ServerlessMarketplace.Domain.User;

public class UserNotFoundException() : Exception(Messages.UserNotFoundException);