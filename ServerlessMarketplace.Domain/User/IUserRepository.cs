﻿namespace ServerlessMarketplace.Domain.User
{
    public interface IUserRepository
    {
        Task<User?> GetBy(Guid userId, string? include = null!, CancellationToken ct = default);
        Task<User?> GetBasicInformation(Guid userId, CancellationToken ct = default);
    }
}
