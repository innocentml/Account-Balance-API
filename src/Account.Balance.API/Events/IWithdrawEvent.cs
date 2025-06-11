namespace Account.Balance.API.Events
{
    /// <summary>
    /// The withdraw event interface.
    /// </summary>
    public interface IWithdrawEvent
    {
        /// <summary>
        /// Createa string representation of JSON object.
        /// </summary>
        /// <returns>Createa string representation of JSON object.</returns>
        public string toJson();
    }
}
