using Newtonsoft.Json.Linq;

namespace Account.Balance.API.Events
{
    /// <summary>
    /// The withdraw event class.
    /// </summary>
    public class WithdrawEvent : IWithdrawEvent
    {
        private readonly long accountId;
        private readonly decimal amount;
        private readonly string status;

        /// <summary>
        /// The WithdrawEvent constructor.
        /// </summary>
        /// <param name="accountId">Unique identifier for account.</param>
        /// <param name="amount">Amount available for the account.</param>
        /// <param name="status">Transaction status.</param>
        public WithdrawEvent(long accountId, decimal amount, string status)
        {
            this.accountId = accountId;
            this.amount = amount;
            this.status = status;
        }

        /// <inheritdoc />
        public string toJson()
        {
            return JObject.Parse(@"{amount: {amount}, accountId: {accountId}, status: {status}}").ToString();
        }
    }
}
