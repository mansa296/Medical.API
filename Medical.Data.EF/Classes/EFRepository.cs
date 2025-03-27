using Medical.Data.EF.Domain;
using Medical.Data.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Medical.Data.EF.Classes
{
    /// <summary>
    /// The ef repository class
    /// </summary>
    /// <seealso cref="IEFRepository{T}"/>
    public class EFRepository<T> : IEFRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// The db context
        /// </summary>
        private readonly MedicalDbContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public EFRepository(MedicalDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Adds the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>A task containing the</returns>
        public async Task<T> AddAsync(T entity)
        {
            var entry = _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Adds the range using the specified entities
        /// </summary>
        /// <param name="entities">The entities</param>
        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            
            var added = await _dbContext.SaveChangesAsync();
            return added == entities.Count();
        }

        /// <summary>
        /// Alls the disable tracking
        /// </summary>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A queryable of t</returns>
        public IQueryable<T> All(bool disableTracking = false)
        {
            if (disableTracking)
            {
                return _dbContext.Set<T>().AsNoTracking().AsQueryable();
            }
            return _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Alls the incude
        /// </summary>
        /// <param name="incude">The incude</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A queryable of t</returns>
        public IQueryable<T> All(Func<IQueryable<T>, IIncludableQueryable<T, object>> incude)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alls the predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A queryable of t</returns>
        public IQueryable<T> All(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alls the predicates
        /// </summary>
        /// <param name="predicates">The predicates</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A queryable of t</returns>
        public IQueryable<T> All(IEnumerable<Expression<Func<T, bool>>> predicates, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Alls the include
        /// </summary>
        /// <param name="include">The include</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>The query</returns>
        public IQueryable<T> All(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (include != null)
            {
                query = include(query);
            }

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            var deleted =  await _dbContext.SaveChangesAsync();

            return deleted != 0;
        }

        /// <summary>
        /// Deletes the range using the specified entities
        /// </summary>
        /// <param name="entities">The entities</param>
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync(); 
        }

        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A queryable of t</returns>
        public IQueryable<T> Find(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <returns>A task containing the</returns>
        public Task<T?> FindAsync(int id, bool disableTracking = true)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Finds the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="incude">The incude</param>
        /// <param name="disableTracking">The disable tracking</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the</returns>
        public Task<T> FindAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> incude, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result != 0;
        }

        /// <summary>
        /// Updates the range of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            var result = await _dbContext.SaveChangesAsync();
            return result != entities.Count();
        }

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> CreateAsync(T entity)
        {
            _dbContext.Set<T>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result != 0;
        }
    }
}