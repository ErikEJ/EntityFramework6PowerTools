namespace System.Data.Entity.SqlServer
{
    /// <summary>
    /// Default configuration.
    /// </summary>
    public class MicrosoftSqlDbConfiguration : DbConfiguration
    {
        /// <summary>
        /// Default configuration.
        /// </summary>
        public MicrosoftSqlDbConfiguration()
        {
            SetProviderFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices("Microsoft.Data.SqlClient", MicrosoftSqlProviderServices.Instance);
        }
    }
}
