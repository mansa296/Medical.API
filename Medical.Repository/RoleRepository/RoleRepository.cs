using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;
using Dapper;

namespace Medical.Repository.RoleRepository
{
    /// <summary>
    /// The role repository class
    /// </summary>
    /// <seealso cref="IRoleRepository"/>
    public class RoleRepository : IRoleRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public RoleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of role</returns>
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<Role>(RoleQueries.GetAll, transaction: _unitOfWork.Transaction);
        }

        /// <summary>
        /// Gets the by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing an enumerable of role</returns>
        public async Task<IEnumerable<Role>> GetByUserIdAsync(int userId)
        {
            return await _unitOfWork.Connection
                .QueryAsync<Role>(RoleQueries.GetAllByUserId, new { userId }, _unitOfWork.Transaction);
        }
        /// <summary>
        /// Gets the by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing an enumerable of role</returns>
        public async Task<IEnumerable<Role>> GetByRoleIdAsync(int roleId)
        {
            return await _unitOfWork.Connection
                .QueryAsync<Role>(RoleQueries.GetAllByRoleId, new { roleId }, _unitOfWork.Transaction);
        }
    }
}