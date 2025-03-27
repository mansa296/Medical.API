using Medical.Data.EF.Domain;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Medical.Data.EF.Interfaces
{
    /// <summary>
    /// The ief repository interface
    /// </summary>
    public interface IEFRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Alls the disable tracking
        /// </summary>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A queryable of t</returns>
        IQueryable<T> All(bool disableTracking = false);
        /// <summary>
        /// Alls the include
        /// </summary>
        /// <param name="include">The include</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A queryable of t</returns>
        IQueryable<T> All(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking = true);
        /// <summary>
        /// Alls the predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A queryable of t</returns>
        IQueryable<T> All(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true);
        /// <summary>
        /// Alls the predicates
        /// </summary>
        /// <param name="predicates">The predicates</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A queryable of t</returns>
        IQueryable<T> All(IEnumerable<Expression<Func<T, bool>>> predicates, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true);
        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A queryable of t</returns>
        IQueryable<T> Find(int id);
        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A task containing the</returns>
        Task<T?> FindAsync(int id, bool disableTracking = true);
        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A task containing the</returns>
        Task<T> FindAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true);
        /// <summary>
        /// Adds the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>A task containing the</returns>
        Task<T> AddAsync(T entity);
        /// <summary>
        /// Adds the range using the specified entities
        /// </summary>
        /// <param name="entities">The entities</param>
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// Deletes the range using the specified entities
        /// </summary>
        /// <param name="entities">The entities</param>
        Task DeleteRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="entities">The entities</param>
        Task<bool> DeleteAsync(T entity);
        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A task containing the bool</returns>
        Task<bool> UpdateAsync(T entity);
        /// <summary>
        /// Updates the range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>A task containing the bool</returns>
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
        /// <summary>
        /// Updates the range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>A task containing the bool</returns>
        Task<bool> CreateAsync(T entity);
    }
}