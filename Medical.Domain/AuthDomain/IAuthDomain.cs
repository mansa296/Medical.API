using Medical.Model.DTOs.Requests.Auth;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using System.Security.Claims;
using Medical.Model.Entities;
using Medical.Model.DTOs.Requests.Users;

namespace Medical.Domain.AuthDomain
{
    /// <summary>
    /// The auth domain interface
    /// </summary>
    public interface IAuthDomain
    {
       
        Task<CommandResponse> LogOut(string token);
        Task<CommandResponse<AuthenticateOTPResponse>> LoginAsync(LoginRequest login);
        Task<CommandResponse<AuthenticateResponse>> OTPVerifyAsync(string email, string opt);
        Task<CommandResponse<AuthenticateResponse>> RefreshTokenAsync(AuthenticateResponse refRequest);
    }
}