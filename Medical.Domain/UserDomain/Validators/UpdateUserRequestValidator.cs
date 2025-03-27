using Medical.Model.DTOs.Requests.Users;
using Medical.Repository.UserRepository;
using FluentValidation;

namespace Medical.Domain.UserDomain.Validators
{
    /// <summary>
    /// The update user request validator class
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateUserRequest}"/>
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserRequestValidator"/> class
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        public UpdateUserRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            CascadeMode = CascadeMode.Stop;

            RuleFor(u => u.UserId)
                .NotEmpty()
                .CustomAsync(ValidateUserExistence);

            RuleFor(u => u.UserName)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(u => u.Mobile)
                .NotEmpty()
                .MaximumLength(11);

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(u => u.IsApprove)
                .NotNull();
        }

        /// <summary>
        /// Validates the user existence using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateUserExistence(int userId, ValidationContext<UpdateUserRequest> context, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(userId);

            if (user is null)
            {
                context.AddFailure(string.Format(UserValidatorErrorMessages.UserDoesNotExist));
            }
        }
    }
}
