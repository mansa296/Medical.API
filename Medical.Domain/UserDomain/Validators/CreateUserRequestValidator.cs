using Medical.Model.DTOs.Requests.Users;
using Medical.Repository.RoleRepository;
using Medical.Repository.UserRepository;
using FluentValidation;
using Medical.Common.Extensions.LINQ;

namespace Medical.Domain.UserDomain.Validators
{
    /// <summary>
    /// The create user request validator class
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateUserRequest}"/>
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IRoleRepository _roleRepository;
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// The azure ad domain
        /// </summary>
       
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRequestValidator"/> class
        /// </summary>
        /// <param name="roleRepository">The role repository</param>
        /// <param name="userRepository">The user repository</param>
        /// <param name="azureAdDomain">The azure ad domain</param>
        public CreateUserRequestValidator(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
           
            CascadeMode = CascadeMode.Stop;

            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50)
                .CustomAsync(ValidateEmailExistence)
                    .When(u => u.IsCreate);

            RuleFor(u => u.Password)
                .MinimumLength(8)
                .WhenAsync(ShouldValidatePassword);

            RuleFor(u => u.Roles)
                .NotEmpty()
                .CustomAsync(ValidateRoleExistence);
        }

        /// <summary>
        /// Validates the role existence using the specified role ids
        /// </summary>
        /// <param name="roleIds">The role ids</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateRoleExistence(int[] roleIds, ValidationContext<CreateUserRequest> context, CancellationToken cancellationToken)
        {
            var roles = (await _roleRepository.GetAllAsync())
                .Select(r => r.RoleId);

            if (!roleIds.IsSubsetOf(roles))
            {
                context.AddFailure(UserValidatorErrorMessages.InvalidRoleId);
            }
        }

        /// <summary>
        /// Validates the email existence using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateEmailExistence(string email, ValidationContext<CreateUserRequest> context, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if(user is not null)
            {
                context.AddFailure(string.Format(UserValidatorErrorMessages.UserAlreadyExist, email));
            }
        }

        /// <summary>
        /// Shoulds the validate password using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the bool</returns>
        private async Task<bool> ShouldValidatePassword(CreateUserRequest request, CancellationToken cancellationToken)
        {
          
            return false;
        }
    }
}