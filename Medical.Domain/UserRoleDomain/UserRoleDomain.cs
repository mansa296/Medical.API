using AutoMapper;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.DTOs.Requests.UserRoles;
using Medical.Model.Entities;
using Medical.Repository.UserRoleRepository;

namespace Medical.Domain.UserRoleDomain
{
    /// <summary>
    /// The user role domain class
    /// </summary>
    /// <seealso cref="IUserRoleDomain"/>
    public class UserRoleDomain : IUserRoleDomain
    {
        /// <summary>
        /// The user role repository
        /// </summary>
        private readonly IUserRoleRepository _userRoleRepository;
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleDomain"/> class
        /// </summary>
        /// <param name="userRoleRepository">The user role repository</param>
        /// <param name="unitOfWork">The unit of work</param>
        /// <param name="mapper">The mapper</param>
        public UserRoleDomain
        (
            IUserRoleRepository userRoleRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Updates the update request
        /// </summary>
        /// <param name="updateRequest">The update request</param>
        public async Task UpdateAsync(UpdateUserRoleRequest updateRequest)
        {
            try
            {
                await _unitOfWork.BeginAsync();

                await _userRoleRepository.DeleteRolesForUserAsync(updateRequest.UserId);

                var userRole = _mapper.Map<UserRole>(updateRequest);
                await _userRoleRepository.CreateAsync(userRole);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
