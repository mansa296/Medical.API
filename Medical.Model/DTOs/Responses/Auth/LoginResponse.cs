using Medical.Model.Entities;

namespace Medical.Model.DTOs.Responses.Auth
{
    /// <summary>
    /// The authenticate response class
    /// </summary>
    public class AuthenticateResponse
    {
        
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserRole? userdetail { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateResponse"/> class
        /// </summary>
        public AuthenticateResponse()
        {
            Token = string.Empty;
            RefreshToken= string.Empty;
        }
    }
    public class AuthenticateOTPResponse
    {

        public string Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateResponse"/> class
        /// </summary>
        public AuthenticateOTPResponse()
        {
            Token = string.Empty;
        }
    }
}
