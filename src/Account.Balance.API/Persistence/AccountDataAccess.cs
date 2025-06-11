using Account.Balance.API.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Account.Balance.API.Persistence
{
    /// <summary>
    /// AccountDataAccess provides methods to access and manipulate account data in the database.
    /// </summary>
    public class AccountDataAccess : IAccountDataAccess
    {
        private readonly IDConnection dConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDataAccess"/> class with the specified database
        /// connection.
        /// </summary>
        /// <param name="dConnection">The database connection to be used for accessing account data. Cannot be null.</param>
        public AccountDataAccess(IDConnection dConnection) 
        {
            this.dConnection = dConnection;
        }

        /// <inheritdoc />
        public async Task<BalanceResponse> GetBalanceAsync(long accountId)
        {
            //This is a placeholder for the actual connection string retrieval logic.
            var connectionString = dConnection.GetConnectionStringAsync();
            using (var connection = new SqlConnection("")) 
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AccountId", accountId, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

                try
                {
                    await connection.OpenAsync();
                    await connection.ExecuteAsync("pr_GetBalance", parameters, commandType: System.Data.CommandType.StoredProcedure);

                }
                catch (Exception)
                {
                    throw;
                }

            }

            // Simulating a response for the sake of example.
            return new BalanceResponse { AccountId = accountId, CurrencyIsoCode = "ZAR", Amount = 100000 };
        }

        /// <inheritdoc />
        public async Task<UpdateBalanceResponse> UpdateBalanceAsync(long accountId, decimal amount)
        {
            //This is a placeholder for the actual connection string retrieval logic.
            var connectionString = dConnection.GetConnectionStringAsync();
            using (var connection = new SqlConnection(""))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@AccountId", accountId, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);
                parameters.Add("@AccountId", amount, System.Data.DbType.Decimal, System.Data.ParameterDirection.Input);

                try
                {
                    await connection.OpenAsync();
                    await connection.ExecuteAsync("pr_UpdateBalance", parameters, commandType: System.Data.CommandType.StoredProcedure);

                }
                catch (Exception)
                {
                    throw;
                }

            }

            // Simulating a response for the sake of example.
            return new UpdateBalanceResponse { AccountId = accountId, CurrencyIsoCode = "ZAR", Amount = 100000 };
        }
    }
}
