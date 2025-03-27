using Medical.Model.DTOs.Requests.Users;
using Medical.Repository.UserRepository;
using FluentValidation;

namespace Medical.Domain.UserDomain.Validators
{
    /// <summary>
    /// The update user country request validator class
    /// </summary>
    /// <seealso cref="AbstractValidator{UpdateCountryRequest}"/>
    public class UpdateUserCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCountryRequestValidator"/> class
        /// </summary>
        /// <param name="userRepository">The user repository</param>
        public UpdateUserCountryRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            CascadeMode = CascadeMode.Stop;

            RuleFor(u => u.UserId)
                .NotEmpty()
                .CustomAsync(ValidateUserExistence);

            RuleFor(u => u.Country)
                .NotNull();
        }

        /// <summary>
        /// Validates the user existence using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="context">The context</param>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ValidateUserExistence(int userId, ValidationContext<UpdateCountryRequest> context, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(userId);

            if (user is null)
            {
                context.AddFailure(string.Format(UserValidatorErrorMessages.UserDoesNotExist));
            }
        }
    }
}