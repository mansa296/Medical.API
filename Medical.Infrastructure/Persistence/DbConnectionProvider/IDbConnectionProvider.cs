using System.Data.Common;

namespace Medical.Infrastructure.Persistence.DbConnectionProvider
{
    /// <summary>
    /// The db connection provider interface
    /// </summary>
    public interface IDbConnectionProvider
    {
        /// <summary>
        /// Gets the connection
        /// </summary>
        /// <returns>The db connection</returns>
        DbConnection GetConnection();
    }
}