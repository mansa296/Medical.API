
using System;

namespace Medical.Model.DTOs.Responses.Auth
{
    public class RefreshTokenResponse
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the token
        /// </summary>
        public string Token { get; set; }
        public RefreshTokenResponse()
        {
            Email = string.Empty;
            Token = string.Empty;
           
        }
    }
}
