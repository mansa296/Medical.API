using Medical.Model.Entities;

namespace Medical.Repository.EndpointRepository
{
    /// <summary>
    /// The endpoint repository interface
    /// </summary>
    public interface IEndpointRepository
    {
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of endpoint</returns>
        Task<IEnumerable<Endpoint>> GetAllAsync();
        /// <summary>
        /// Gets the by id using the specified endpoint id
        /// </summary>
        /// <param name="endpointId">The endpoint id</param>
        /// <returns>A task containing the endpoint</returns>
        Task<Endpoint> GetByIdAsync(int endpointId);
        /// <summary>
        /// Gets the by name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>A task containing the endpoint</returns>
        Task<Endpoint> GetByNameAsync(string name);
        /// <summary>
        /// Creates the endpoint
        /// </summary>
        /// <param name="endpoint">The endpoint</param>
        /// <returns>A task containing the int</returns>
        Task<int> CreateAsync(Endpoint endpoint);
        /// <summary>
        /// Updates the endpoint
        /// </summary>
        /// <param name="endpoint">The endpoint</param>
        /// <returns>A task containing the bool</returns>
        Task<bool> UpdateAsync(Endpoint endpoint);
        /// <summary>
        /// Deletes the endpoint id
        /// </summary>
        /// <param name="endpointId">The endpoint id</param>
        /// <returns>A task containing the bool</returns>
        Task<bool> DeleteAsync(int endpointId);
    }
}