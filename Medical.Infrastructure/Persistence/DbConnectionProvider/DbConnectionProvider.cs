using Medical.Common;
using Medical.Model.Options;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Data.SqlClient;

namespace Medical.Infrastructure.Persistence.DbConnectionProvider
{
    /// <summary>
    /// The db connection provider class
    /// </summary>
    /// <seealso cref="IDbConnectionProvider"/>
    public class DbConnectionProvider : IDbConnectionProvider
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly DataAccessOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbConnectionProvider"/> class
        /// </summary>
        /// <param name="options">The options</param>
        public DbConnectionProvider(IOptions<DataAccessOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Gets the connection
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The db connection</returns>
        public DbConnection GetConnection()
        {
            if (!string.IsNullOrWhiteSpace(_options?.ConnectionString))
            {
                return new Microsoft.Data.SqlClient.SqlConnection(_options.ConnectionString);
            }

            throw new ArgumentNullException(ErrorMessages.ConnectionStringIsNotProvided);
        }
    }
}
