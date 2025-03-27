using FluentValidation;
using Medical.Model.DTOs.Requests.UserRoles;
using Medical.Repository.RoleRepository;
using Medical.Repository.UserRepository;

namespace Medical.Domain.UserRoleDomain.Validators
{
    /// <summary>
    /// The update user role request validator class
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateUserRoleRequest}"/>
    public class UpdateUserRoleRequestValidator : AbstractValidator<UpdateUserRoleRequest>
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
        /// Initializes a new instance of the <see cref="UpdateUserRoleRequestValidator"/> class
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        /// <param name="roleRepository">The role repository</param>
        public UpdateUserRoleRequestValidator(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;

            CascadeMode = CascadeMode.Stop;

            RuleFor(u => u.UserId)
                .NotEmpty()
                .CustomAsync(ValidateUserExistence);

            RuleFor(u => u.RoleId)
                .NotEmpty()
                .CustomAsync(ValidateRoleExistence);
        }

        /// <summary>
        /// Validates the role existence using the specified role id
        /// </summary>
        /// <param name="roleId">The role id</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateRoleExistence(int roleId, ValidationContext<UpdateUserRoleRequest> context, CancellationToken cancellationToken)
        {
            var roles = (await _roleRepository.GetAllAsync())
                .Select(r => r.RoleId);

            if (!roles.Contains(roleId))
            {
                context.AddFailure(UserRoleValidatorErrorMessages.InvalidRoleId);
            }
        }

        /// <summary>
        /// Validates the user existence using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateUserExistence(int userId, ValidationContext<UpdateUserRoleRequest> context, CancellationToken cancellationToken)
        {
            var user = (await _userRepository.GetByUserIdAsync(userId));

            if (user is null)
            {
                context.AddFailure(UserRoleValidatorErrorMessages.UserDoesNotExist);
            }
        }
    }
}