using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;
using Dapper;

namespace Medical.Repository.EndpointRepository
{
    /// <summary>
    /// The endpoint repository class
    /// </summary>
    /// <seealso cref="IEndpointRepository"/>
    public class EndpointRepository : IEndpointRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public EndpointRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the endpoint
        /// </summary>
        /// <param name="endpoint">The endpoint</param>
        /// <returns>A task containing the int</returns>
        public async Task<int> CreateAsync(Endpoint endpoint)
        {
            var query = string.Concat(EndpointQueries.Create, " ", CommonQueries.SelectScopeIdentity);
            return await _unitOfWork.Connection.ExecuteScalarAsync<int>(query, endpoint, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Deletes the endpoint id
        /// </summary>
        /// <param name="endpointId">The endpoint id</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> DeleteAsync(int endpointId)
        {
            var result = await _unitOfWork.Connection
                .ExecuteAsync(EndpointQueries.Delete, new { endpointId }, _unitOfWork.Transaction);

            return result != 0;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of endpoint</returns>
        public async Task<IEnumerable<Endpoint>> GetAllAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<Endpoint>(EndpointQueries.GetAll);
        }

        /// <summary>
        /// Gets the by id using the specified endpoint id
        /// </summary>
        /// <param name="endpointId">The endpoint id</param>
        /// <returns>A task containing the endpoint</returns>
        public async Task<Endpoint> GetByIdAsync(int endpointId)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<Endpoint>(EndpointQueries.GetById, new { endpointId });
        }

        /// <summary>
        /// Gets the by name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>A task containing the endpoint</returns>
        public async Task<Endpoint> GetByNameAsync(string name)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<Endpoint>(EndpointQueries.GetByName, new { name });
        }

        /// <summary>
        /// Updates the endpoint
        /// </summary>
        /// <param name="endpoint">The endpoint</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> UpdateAsync(Endpoint endpoint)
        {
            var updatedRows = await _unitOfWork.Connection
                .ExecuteAsync(EndpointQueries.Update, endpoint, _unitOfWork.Transaction);

            return updatedRows != 0;
        }
    }
}