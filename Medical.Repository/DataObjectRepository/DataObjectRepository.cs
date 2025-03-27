using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;
using Dapper;

namespace Medical.Repository.DataObjectRepository
{
    /// <summary>
    /// The data object repository class
    /// </summary>
    /// <seealso cref="IDataObjectRepository"/>
    public class DataObjectRepository : IDataObjectRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataObjectRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public DataObjectRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the data object
        /// </summary>
        /// <param name="dataObject">The data object</param>
        /// <returns>A task containing the int</returns>
        public async Task<int> CreateAsync(DataObject dataObject)
        {
            var query = string.Concat(DataObjectQueries.Create, " ", CommonQueries.SelectScopeIdentity);
            return await _unitOfWork.Connection.ExecuteScalarAsync<int>(query, dataObject, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Deletes the data object id
        /// </summary>
        /// <param name="dataObjectId">The data object id</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> DeleteAsync(int dataObjectId)
        {
            var result = await _unitOfWork.Connection
                .ExecuteAsync(DataObjectQueries.Delete, new { dataObjectId }, _unitOfWork.Transaction);

            return result != 0;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of data object</returns>
        public async Task<IEnumerable<DataObject>> GetAllAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<DataObject>(DataObjectQueries.GetAll);
        }

        /// <summary>
        /// Gets the by id using the specified data object id
        /// </summary>
        /// <param name="dataObjectId">The data object id</param>
        /// <returns>A task containing the data object</returns>
        public async Task<DataObject> GetByIdAsync(int dataObjectId)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<DataObject>(DataObjectQueries.GetById, new { dataObjectId });
        }

        /// <summary>
        /// Gets the by name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>A task containing the data object</returns>
        public async Task<DataObject> GetByNameAsync(string name)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<DataObject>(DataObjectQueries.GetByName, new { name });
        }

        /// <summary>
        /// Gets the by txture id using the specified txture id
        /// </summary>
        /// <param name="txtureId">The txture id</param>
        /// <returns>A task containing the data object</returns>
        public async Task<DataObject> GetByTxtureIdAsync(string txtureId)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<DataObject>(DataObjectQueries.GetByTxtureId, new { txtureId });
        }

        /// <summary>
        /// Updates the data object
        /// </summary>
        /// <param name="dataObject">The data object</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateAsync(DataObject dataObject)
        {
            var updatedRows = await _unitOfWork.Connection
                .ExecuteAsync(DataObjectQueries.Update, dataObject, _unitOfWork.Transaction);

            return updatedRows != 0;
        }
    }
}