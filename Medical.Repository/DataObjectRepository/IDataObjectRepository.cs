using Medical.Model.Entities;

namespace Medical.Repository.DataObjectRepository
{
    /// <summary>
    /// The data object repository interface
    /// </summary>
    public interface IDataObjectRepository
    {
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of data object</returns>
        Task<IEnumerable<DataObject>> GetAllAsync();
        /// <summary>
        /// Gets the by id using the specified data object id
        /// </summary>
        /// <param name="dataObjectId">The data object id</param>
        /// <returns>A task containing the data object</returns>
        Task<DataObject> GetByIdAsync(int dataObjectId);
        /// <summary>
        /// Gets the by txture id using the specified txture id
        /// </summary>
        /// <param name="txtureId">The txture id</param>
        /// <returns>A task containing the data object</returns>
        Task<DataObject> GetByTxtureIdAsync(string txtureId);
        /// <summary>
        /// Gets the by name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>A task containing the data object</returns>
        Task<DataObject> GetByNameAsync(string name);
        /// <summary>
        /// Creates the data object
        /// </summary>
        /// <param name="dataObject">The data object</param>
        /// <returns>A task containing the int</returns>
        Task<int> CreateAsync(DataObject dataObject);
        /// <summary>
        /// Updates the data object
        /// </summary>
        /// <param name="dataObject">The data object</param>
        /// <returns>A task containing the bool</returns>
        Task<bool> UpdateAsync(DataObject dataObject);
        /// <summary>
        /// Deletes the data object id
        /// </summary>
        /// <param name="dataObjectId">The data object id</param>
        /// <returns>A task containing the bool</returns>
        Task<bool> DeleteAsync(int dataObjectId);
    }
}