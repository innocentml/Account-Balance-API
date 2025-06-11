namespace Account.Balance.API.Handlers
{
    /// <summary>
    /// Interface for handling withdrawal operations.
    /// </summary>
    public interface IWithdrawHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId">Unique identifier for account.</param>
        /// <param name="amount">Amount available for the account.</param>
        /// <returns></returns>
        Task<string> GetResponseAsync(long accountId, decimal amount);
    }
}
