namespace Account.Balance.API.Models
{
    public class UpdateBalanceResponse
    {
        /// <summary>
        /// Unique identifier for account.
        /// </summary>
        public long AccountId { get; set; }


        /// <summary>
        /// Amount available for the account.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the ISO 4217 currency code representing the currency.
        /// </summary>
        /// <remarks>The value must be a valid ISO 4217 currency code. Invalid or unrecognized codes may
        /// result in unexpected behavior when used in operations that depend on currency information.</remarks>
        public required string CurrencyIsoCode { get; set; }
    }
}
