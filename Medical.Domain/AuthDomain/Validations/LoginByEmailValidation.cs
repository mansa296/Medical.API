using Medical.Model.DTOs.Requests.Auth;
using FluentValidation;

namespace Medical.Domain.AuthDomain.Validations
{
    /// <summary>
    /// The login by email validation class
    /// </summary>
    /// <seealso cref="AbstractValidator{LoginByEmailRequest}"/>
    public class LoginByEmailValidation : AbstractValidator<LoginByEmailRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginByEmailValidation"/> class
        /// </summary>
        public LoginByEmailValidation()
        {
            RuleFor(r => r.Email).EmailAddress();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}
