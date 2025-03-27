using Medical.Model.Entities;
using Dapper;
using Medical.Model.DTOs.Requests;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.DTOs.Requests.Users;

namespace Medical.Repository.UserRepository
{
    /// <summary>
    /// The user repository class
    /// </summary>
    /// <seealso cref="IUserRepository"/>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A task containing the int</returns>
        public async Task<int> CreateAsync(Users user)
        {
            var query = string.Concat(UserQueries.Create, " ", CommonQueries.SelectScopeIdentity);
            return await _unitOfWork.Connection.ExecuteScalarAsync<int>(query, user, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">The user</param>
        public async Task UpdateAsync(Users user)
        {
            await _unitOfWork.Connection.ExecuteAsync(UserQueries.Update, user, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Updates the activity status using the specified activity status request
        /// </summary>
        /// <param name="activityStatusRequest">The activity status request</param>
        public async Task UpdateActivityStatusAsync(UpdateActivityStatusRequest activityStatusRequest)
        {
            await _unitOfWork.Connection.ExecuteAsync(UserQueries.UpdateActivityStatus, activityStatusRequest, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Updates the country using the specified country request
        /// </summary>
        /// <param name="countryRequest">The country request</param>
        public async Task UpdateCountryAsync(UpdateCountryRequest countryRequest)
        {
            await _unitOfWork.Connection.ExecuteAsync(UserQueries.UpdateCountry, countryRequest, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Gets the all using the specified paginated request
        /// </summary>
        /// <param name="paginatedRequest">The paginated request</param>
        /// <returns>A task containing an enumerable of user</returns>
        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            //if (paginatedRequest.IsValid())
            //{
            //    var query = string.Concat(UserQueries.GetAll, " ", CommonQueries.PaginatedQuery);
            //    return await _unitOfWork.Connection.QueryAsync<AspNetUsers>(query, paginatedRequest);
            //}

            return await _unitOfWork.Connection.QueryAsync<Users>(UserQueries.GetAll);
        }

        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        public async Task<Users> GetByUserIdAsync(int userId)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<Users>(UserQueries.GetByUserId, new { userId });
        }
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        public async Task<Users> GetByIdAsync(string id)
        {
            return await _unitOfWork.Connection
                .QuerySingleOrDefaultAsync<Users>(UserQueries.GetById, new { id });
        }
        /// <summary>
        /// Gets the user by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing the user</returns>
        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _unitOfWork.Connection
                .QueryFirstOrDefaultAsync<Users>(UserQueries.GetByEmail, new { email });
        }
        /// <summary>
        /// Gets the user by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="BusinessUnitId">The email</param>
        /// <returns>A task containing the user</returns>
        public async Task<Users?> GetUserByEmailBUAsync(string email, Guid UserBUId)
        {
            return await _unitOfWork.Connection
                .QueryFirstOrDefaultAsync<Users>(UserQueries.GetByEmailBU, new { email, UserBUId });
        }
        public async Task<UserLogin?> GetUserByEmailPasswordAsync(string email, string password)
        {
            try
            {
                return await _unitOfWork.Connection
                    .QueryFirstOrDefaultAsync<UserLogin>(UserQueries.GetByEmailPassword, new { email, password });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
    }
}