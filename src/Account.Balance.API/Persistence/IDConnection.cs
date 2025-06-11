namespace Account.Balance.API.Persistence
{
    public interface IDConnection
    {
        /// <summary>
        /// Gets the connection string for the database.
        /// </summary>
        /// <returns>The connection string.</returns>
        string GetConnectionStringAsync();
    }
}
