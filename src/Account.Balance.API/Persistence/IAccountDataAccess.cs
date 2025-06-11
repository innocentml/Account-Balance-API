using Account.Balance.API.Models;

namespace Account.Balance.API.Persistence
{
    /// <summary>
    /// Interface for account data access operations.
    /// </summary>
    public interface IAccountDataAccess
    {
        /// <summary>
        /// Logic to get the balance for the account.
        /// </summary>
        /// <param name="accountId">Unique identifier for account.</param>
        /// <returns></returns>
        Task<BalanceResponse> GetBalanceAsync(long accountId);

        /// <summary>
        /// Logic to update the balance for the account.
        /// </summary>
        /// <param name="accountId">Unique identifier for account.</param>
        /// <param name="amount">Amount available for the account.</param>
        Task<UpdateBalanceResponse> UpdateBalanceAsync(long accountId, decimal amount);
    }
}
