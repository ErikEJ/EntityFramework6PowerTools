namespace System.Data.Entity.SqlServerCompact
{
    /// <summary>
    /// Default configuration.
    /// </summary>
    public class SqlCeDbConfiguration : DbConfiguration
    {
        /// <summary>
        /// Default configuration, used for code based configuration of this provider.
        /// </summary>
        public SqlCeDbConfiguration()
        {
            SetProviderFactory(SqlCeProviderServices.ProviderInvariantName, SqlServerCe.SqlCeProviderFactory.Instance);
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
        }
    }
}
