using Account.Balance.API.Events;
using Account.Balance.API.Exceptions;
using Account.Balance.API.Persistence;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Account.Balance.API.Handlers
{
    /// <summary>
    /// Handles withdrawal operations for accounts.
    /// </summary>
    /// <remarks>This class provides functionality to process withdrawal requests by interacting with the
    /// underlying account system. Implementations of this class should define the behavior for handling withdrawal
    /// responses.
    /// </remarks>
    /// <param name="accountDataAccess"></param>
    /// <param name="logger"></param>
    public class WithdrawHandler(IAccountDataAccess accountDataAccess, ILogger<WithdrawHandler> logger) : IWithdrawHandler
    {
        private readonly IAccountDataAccess accountDataAccess = accountDataAccess;
        private readonly ILogger<WithdrawHandler> logger = logger;

        /// <inheritdoc />
        public async Task<string> GetResponseAsync(long accountId, decimal amount)
        {
            try
            {
                var balanceResponse = await accountDataAccess.GetBalanceAsync(accountId);
                if(balanceResponse.Amount >= amount) 
                {
                    await accountDataAccess.UpdateBalanceAsync(accountId, amount);
                    await PublishEventAsync(amount, accountId, "SUCCESSFUL");

                    return "Withdrawal successful";
                }
                await PublishEventAsync(amount, accountId, "UNSUCCESSFUL");

                return "Insufficient funds for withdrawal";
            }
            catch (GetBalanceException)
            {
                logger.LogError($"Error happened while trying to get balance for the accountId: {accountId}");
                await PublishEventAsync(amount, accountId, "UNSUCCESSFUL");
                throw;
            }
            catch (UpdateBalanceException)
            {
                logger.LogError($"Error happened while trying to update the balance for the accountId: {accountId}");
                await PublishEventAsync(amount, accountId, "UNSUCCESSFUL");
                return "Withdrawal failed";
            }
            catch (Exception)
            {
                logger.LogError($"Unknow error happened will to proccess withdrawal for accountId: {accountId}");
                await PublishEventAsync(amount, accountId, "UNSUCCESSFUL");
                return "Withdrawal failed";
            }
        }

        private async Task PublishEventAsync(decimal amount, long accountId, string status)
        {
            var withdrawEvent = new WithdrawEvent(accountId, amount, status);
            var client = new AmazonSimpleNotificationServiceClient();
            var request = new PublishRequest()
            {
                Subject = "WithdrawEventAddedEvent",
                Message = withdrawEvent.toJson(),
                TopicArn = "arn:aws:sns:us-east-1:189107071895:weather-forecast",
            };
            try
            {
                await client.PublishAsync(request);
            }
            catch (Exception)
            {
                logger.LogError($"Unknow error happened when publishing withdraw event for accountId: {accountId}");
                throw;
            }
        }
    }
}
