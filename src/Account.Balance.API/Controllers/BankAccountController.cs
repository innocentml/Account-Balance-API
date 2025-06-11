using Account.Balance.API.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Account.Balance.API.Controllers
{
    /// <summary>
    /// Provides endpoints for managing bank account operations, such as withdrawals.
    /// </summary>
    /// <remarks>This controller handles HTTP requests related to bank account operations. It relies on an
    /// injected <see cref="IWithdrawHandler"/> to process withdrawal requests.</remarks>
    [Route("/bank")]
    public class BankAccountController : Controller
    {
        private readonly IWithdrawHandler withdrawHandler;

        /// <summary>
        /// The BankAccountController constructor.
        /// </summary>
        /// <param name="withdrawHandler">The withdraw handler.</param>
        public BankAccountController(IWithdrawHandler withdrawHandler)
        {
            this.withdrawHandler = withdrawHandler;
        }

        /// <summary>
        /// The withdraw endpoint.
        /// </summary>
        /// <param name="accountId">Unique identifier for account.</param>
        /// <param name="amount">Amount available for the account.</param>
        /// <returns>SUCCESSFUL or UNSUCCESSFUL response string.</returns>
        [HttpPost]
        [Route("/withdraw")]
        public async Task<string> Withdraw([Required] long accountId, [Required] decimal amount)
        {
            return await withdrawHandler.GetResponseAsync(accountId, amount);
        }
    }
}
