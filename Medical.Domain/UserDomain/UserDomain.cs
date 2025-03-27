using AutoMapper;
using Medical.Common;
using Medical.Common.Constants;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Infrastructure.Security.TokenProvider;
using Medical.Model.DTOs.Requests;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.DTOs.Responses.Users;
using Medical.Model.Entities;
using Medical.Repository.RoleRepository;
using Medical.Repository.TokenRepository;
using Medical.Repository.UserRepository;
using Medical.Repository.UserRoleRepository;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;


namespace Medical.Domain.UserDomain
{
    /// <summary>
    /// The user domain class
    /// </summary>
    /// <seealso cref="IUserDomain"/>
    public class UserDomain : IUserDomain
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IRoleRepository _roleRepository;
        /// <summary>
        /// The user role repository
        /// </summary>
        private readonly IUserRoleRepository _userRoleRepository;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// The token provider
        /// </summary>
        private readonly ITokenProvider _tokenProvider;
        /// <summary>
        /// The token repository
        /// </summary>
        private readonly ITokenRepository _tokenRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDomain"/> class
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="roleRepository">The role repository</param>
        /// <param name="userRoleRepository">The user role repository</param>
        /// <param name="mapper">The mapper</param>
        /// <param name="unitOfWork">The unit of work</param>
        /// <param name="tenantRepository">The tenant repository</param>
        /// <param name="configuration">The configuration</param>
        /// <param name="tokenProvider">The token provider</param>
        /// <param name="tokenRepository">The token repository</param>
        public UserDomain
        (
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            ITokenProvider tokenProvider,
             ITokenRepository tokenRepository
        )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _tokenProvider = tokenProvider;
            _tokenRepository = tokenRepository;
        }

        /// <summary>
        /// Creates the create request
        /// </summary>
        /// <param name="createRequest">The create request</param>
        public async Task CreateAsync(CreateUserRequest createRequest)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                var user = _mapper.Map<Users>(createRequest);
                var userId = await _userRepository.CreateAsync(user);

                //var userRoleTasks = createRequest.Roles.Select(r =>
                //{
                //    UserRole userRole = new()
                //    {
                //        RoleId = r,
                //        UserId = userId
                //    };

                //    return _userRoleRepository.CreateAsync(userRole);
                //});

                //await Task.WhenAll(userRoleTasks);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Gets the all using the specified paginated request
        /// </summary>
        /// <param name="paginatedRequest">The paginated request</param>
        /// <returns>A task containing a command response of i enumerable user with roles response</returns>
        public async Task<CommandResponse<IEnumerable<Users>>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return CommandResponse<IEnumerable<Users>>.Succeeded(users);
        }

        /// <summary>
        /// Gets the by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>The user</returns>
        public async Task<Users?> GetByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        /// <summary>
        /// Gets the by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        public async Task<CommandResponse<UserWithRolesResponse>> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user is not null)
            {
                var response = new UserWithRolesResponse()
                {
                    Roles = await _roleRepository.GetByUserIdAsync(user.UserId)
                };

                _mapper.Map(user, response);

                return CommandResponse<UserWithRolesResponse>.Succeeded(response);
            }

            return CommandResponse<UserWithRolesResponse>.Failed();
        }

        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        public async Task<CommandResponse<Users>> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetByUserIdAsync(userId);

            if (user is not null)
            {
                return CommandResponse<Users>.Succeeded(user);
            }

            return CommandResponse<Users>.Failed();
        }

        /// <summary>
        /// Updates the activity status using the specified activity status request
        /// </summary>
        /// <param name="activityStatusRequest">The activity status request</param>
        public async Task UpdateActivityStatusAsync(UpdateActivityStatusRequest activityStatusRequest)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _userRepository.UpdateActivityStatusAsync(activityStatusRequest);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Updates the update request
        /// </summary>
        /// <param name="updateRequest">The update request</param>
        public async Task UpdateAsync(UpdateUserRequest updateRequest)
        {
            try
            {
                var user = await _userRepository.GetByUserIdAsync(updateRequest.UserId);

                await _unitOfWork.BeginAsync();

                if (user is not null)
                {
                    _mapper.Map(updateRequest, user);
                    await _userRepository.UpdateAsync(user);

                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Updates the country using the specified country request
        /// </summary>
        /// <param name="countryRequest">The country request</param>
        public async Task UpdateCountryAsync(UpdateCountryRequest countryRequest)
        {
            try
            {
                await _unitOfWork.BeginAsync();
                await _userRepository.UpdateCountryAsync(countryRequest);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
        /// <summary>
        /// Gets the by email & claims principal 
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="claimsPrincipal">The claims principal</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        public async Task<CommandResponse<AuthenticateResponse>> GetUserDetailByEmailAsync(string email)
        {
            var response = new CommandResponse<AuthenticateResponse>()
                .MarkFailed(ErrorMessages.NotAuthorizedContactAdmin);


            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user is not null)
            {

                if (user?.IsApprove == true)
                {
                    var claims = new List<Claim>
                            {
                                new(ClaimTypes.Email, user.Email),
                                new(ClaimTypes.NameIdentifier, user.UserId.ToString())
                            };
                    var authResponse = new AuthenticateResponse();
                    authResponse.Token = _tokenProvider.GenerateToken(claims.ToArray());
                    //var authResponse = await AuthenticateUserAsync(user);
                    response.MarkSucceded(result: authResponse);
                }

            }
            return response;
        }
        
    }
}