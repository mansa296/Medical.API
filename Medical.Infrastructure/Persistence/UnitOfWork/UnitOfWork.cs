using Medical.Infrastructure.Persistence.DbConnectionProvider;
using System.Data;
using System.Data.Common;

namespace Medical.Infrastructure.Persistence.UnitOfWork
{
    /// <summary>
    /// The unit of work class
    /// </summary>
    /// <seealso cref="IUnitOfWork"/>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// The connection
        /// </summary>
        private readonly DbConnection _connection;
        /// <summary>
        /// The transaction
        /// </summary>
        private DbTransaction _transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class
        /// </summary>
        /// <param name="connectionProvider">The connection provider</param>
        public UnitOfWork(IDbConnectionProvider connectionProvider)
        {
            _connection = connectionProvider.GetConnection();
        }

        /// <summary>
        /// Gets the value of the connection
        /// </summary>
        public DbConnection Connection => _connection;
        /// <summary>
        /// Gets the value of the transaction
        /// </summary>
        public DbTransaction? Transaction => _transaction;

        /// <summary>
        /// Begins this instance
        /// </summary>
        public async Task BeginAsync()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }

            _transaction = await _connection.BeginTransactionAsync();
        }

        /// <summary>
        /// Commits this instance
        /// </summary>
        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        /// <summary>
        /// Rollbacks this instance
        /// </summary>
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_connection != null)
                {
                    _connection.Dispose();

                }

               
            }
            _disposed = true;
        }
        
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
