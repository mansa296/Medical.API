using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;
using Medical.Repository.UserRepository;
using Dapper;

namespace Medical.Repository.UserRoleRepository
{
    /// <summary>
    /// The user role repository class
    /// </summary>
    /// <seealso cref="IUserRoleRepository"/>
    public class UserRoleRepository : IUserRoleRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public UserRoleRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the user role
        /// </summary>
        /// <param name="userRole">The user role</param>
        public async Task CreateAsync(UserRole userRole)
        {
            await _unitOfWork.Connection.ExecuteAsync(UserRoleQueries.Create, userRole, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Deletes the roles for user using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        public async Task DeleteRolesForUserAsync(int userId)
        {
            await _unitOfWork.Connection.ExecuteAsync(UserRoleQueries.DeleteRolesForUser, new { userId }, _unitOfWork.Transaction);
        }
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        public async Task<Role> GetRoleByUserAsync(int userId)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<Role>(UserRoleQueries.GetRoleByUser, new { userId });
        }
    }
}
