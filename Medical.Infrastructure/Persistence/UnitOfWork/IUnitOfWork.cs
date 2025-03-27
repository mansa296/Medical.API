using System.Data;
using System.Data.Common;

namespace Medical.Infrastructure.Persistence.UnitOfWork
{
    /// <summary>
    /// The unit of work interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the value of the connection
        /// </summary>
        DbConnection Connection { get; }
        /// <summary>
        /// Gets the value of the transaction
        /// </summary>
        DbTransaction? Transaction { get; }
        /// <summary>
        /// Begins this instance
        /// </summary>
        Task BeginAsync();
        /// <summary>
        /// Commits this instance
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// Rollbacks this instance
        /// </summary>
        Task RollbackAsync();
    }
}