using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Medical.Common;
using Medical.Common.Constants;
using Medical.Data.EF;
using Medical.Infrastructure.Security.TokenProvider;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.Entities;
using Medical.Repository.TokenRepository;
using Medical.Repository.UserRepository;
using RestSharp;
using System;
using System.Threading.Tasks;
using System.Security.Authentication;

namespace Medical.Domain.AuthDomain
{
    public class AuthDomain : IAuthDomain
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenProvider _tokenProvider;
        private readonly ITokenRepository _tokenRepository;
        private readonly MedicalDbContext _dbContext;

        public AuthDomain(
            IUserRepository userRepository,
            IMapper mapper,
            ITokenProvider tokenProvider,
            ITokenRepository tokenRepository,
            MedicalDbContext dbContext

            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenProvider = tokenProvider;
            _tokenRepository = tokenRepository;
            _dbContext = dbContext;


        }

       
        public async Task<CommandResponse> LogOut(string token)
        {
            var response = new CommandResponse(false)
                .MarkFailed(ErrorMessages.NotAuthorizedContactAdmin);

            var userToken = await _tokenRepository.GetByValueAsync(token.Replace("Bearer ", ""));
            if (userToken is not null)
            {
                userToken.IsLoggedOut = true;
                await _tokenRepository.UpdateAsync(userToken);
                return response.MarkSucceded();
            }

            return response;

        }
        public async Task<CommandResponse<AuthenticateOTPResponse>> LoginAsync(LoginRequest login)
        {
            var response = new CommandResponse<AuthenticateOTPResponse>()
                .MarkFailed(ErrorMessages.NotAuthorizedContactAdmin);

            try
            {
                if (login.Email is not null)
                {
                    var loginResult = await _userRepository.GetUserByEmailPasswordAsync(login.Email, login.Password);
                    if (loginResult is not null)
                    {
                        try
                        {
                            var userrole = new List<UserRole>();
                            var authResponse = new AuthenticateOTPResponse();
                            var operationParam = new Microsoft.Data.SqlClient.SqlParameter("@Operation", "GetAccountUserName");
                            var emailParam = new Microsoft.Data.SqlClient.SqlParameter("@UserName", login.Email);
                            userrole = _dbContext.UserRole.FromSqlRaw("EXEC procAccount @Operation, @UserName", operationParam, emailParam).ToList();

                            await SendOTPAsync(userrole.FirstOrDefault()?.Mobile);
                            var claims = new List<Claim>
                            {
                                new(ClaimTypes.Email, login.Email),
                                new(ClaimTypes.NameIdentifier, loginResult.Userid.ToString())
                            };
                            authResponse.Token = _tokenProvider.OtpGenerateToken(claims.ToArray());
                            response.MarkSucceded(result: authResponse);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                }
                else
                {
                    return response.MarkFailed(ErrorMessages.InactiveUserContactAdmin);
                }
            }

            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public async Task<CommandResponse<AuthenticateResponse>> OTPVerifyAsync(string email, string opt)
        {
            var response = new CommandResponse<AuthenticateResponse>()
                .MarkFailed(ErrorMessages.OTPTokenNotVerify);

            try
            {
                var userrole = new List<UserRole>();
                var authResponse = new AuthenticateResponse();
                var operationParam = new Microsoft.Data.SqlClient.SqlParameter("@Operation", "GetAccountUserName");
                var emailParam = new Microsoft.Data.SqlClient.SqlParameter("@UserName", email);
                userrole = _dbContext.UserRole.FromSqlRaw("EXEC procAccount @Operation, @UserName", operationParam, emailParam).ToList();

                if (await VerifyOTPAsync(userrole.FirstOrDefault().Mobile, opt)==true)
                {
                    var claims = new List<Claim>
                {
                    new(ClaimTypes.Email, email),
                    new(ClaimTypes.NameIdentifier, userrole.FirstOrDefault().UserId.ToString())
                };
                    authResponse.Token = _tokenProvider.GenerateToken(claims.ToArray());
                    authResponse.RefreshToken = Base64Encode(userrole.FirstOrDefault().Id.ToString());
                    authResponse.userdetail = userrole.FirstOrDefault();
                    response.MarkSucceded(result: authResponse);
                }
                
                    
            }

            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public async Task<CommandResponse<AuthenticateResponse>> RefreshTokenAsync(AuthenticateResponse refRequest)
        {
            var response = new CommandResponse<AuthenticateResponse>()
                .MarkFailed(ErrorMessages.NotAuthorizedContactAdmin);

            try
            {
                if (refRequest.RefreshToken is not null)
                {
                    var loginResult = await _userRepository.GetByIdAsync(Base64Decode(refRequest.RefreshToken));
                    if (loginResult is not null)
                    {
                        try
                        {
                            var userrole = new List<UserRole>();
                            var authResponse = new AuthenticateResponse();
                            var operationParam = new Microsoft.Data.SqlClient.SqlParameter("@Operation", "GetAccountUserName");
                            var emailParam = new Microsoft.Data.SqlClient.SqlParameter("@UserName", loginResult.Email);
                            userrole = _dbContext.UserRole.FromSqlRaw("EXEC procAccount @Operation, @UserName", operationParam, emailParam).ToList();
                            var claims = new List<Claim>
                            {
                                new(ClaimTypes.Email, loginResult.Email),
                                new(ClaimTypes.NameIdentifier, loginResult.UserId.ToString())
                            };
                            authResponse.Token = _tokenProvider.GenerateToken(claims.ToArray());
                            authResponse.RefreshToken = Base64Encode(loginResult.Id.ToString());
                            authResponse.userdetail = userrole.FirstOrDefault();
                            response.MarkSucceded(result: authResponse);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                }
                else
                {
                    return response.MarkFailed(ErrorMessages.InactiveUserContactAdmin);
                }
            }

            catch (Exception)
            {

                throw;
            }
            return response;
        }
        public async Task SendOTPAsync(string? mobile)
        {
            // Construct the full URL with query parameters
            var baseUrl = "https://api.msg91.com/api/v5/otp";

            try
            {
                // Create a RestClient instance with the base URL
                var client = new RestClient(baseUrl);

                // Create a RestRequest instance with the endpoint and method
                var request = new RestRequest();
                request.AddQueryParameter("template_id", "63df3165d6fc050cb517eee7");
                request.AddQueryParameter("mobile", $"91{mobile}");
                request.AddQueryParameter("authkey", "325791AwTEkoGFG5e8f6220P1");
                request.AddQueryParameter("otp_length", "6");
                request.AddQueryParameter("otp_expiry", "5");

                // Send the request and get the response asynchronously
                var response = await client.GetAsync(request);

                // Check if the request was successful
                if (response.IsSuccessful)
                {
                    // Output the response content
                    Console.WriteLine(response.Content);
                }
                else
                {
                    // Handle errors
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
        //public async Task SendOTPAsync(string? mobile)
        //{

        //    // Construct the full URL with query parameters
        //    var baseUrl = "https://api.msg91.com/api/v5/otp";
        //    //var requestUrl = $"{baseUrl}?template_id=63df3165d6fc050cb517eee7&mobile=91{mobile}&authkey=325791AwTEkoGFG5e8f6220P1&otp_length=6&otp_expiry=5";

        //    try
        //    {
        //        // Create a RestClient instance with the base URL
        //        var client = new RestClient(baseUrl);

        //        // Create a RestRequest instance with the endpoint and method
        //        var request = new RestRequest(Method.GET);
        //        request.AddParameter("template_id", "63df3165d6fc050cb517eee7");
        //        request.AddParameter("mobile", $"91{mobile}");
        //        request.AddParameter("authkey", "325791AwTEkoGFG5e8f6220P1");
        //        request.AddParameter("otp_length", "6");
        //        request.AddParameter("otp_expiry", "5");

        //        // Send the request and get the response asynchronously
        //        IRestResponse response = client.Execute(request);

        //        //// Check if the request was successful
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            // Output the response content
        //            Console.WriteLine(response.Content);
        //        }
        //        else
        //        {
        //            // Handle errors
        //            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions
        //        Console.WriteLine($"Exception: {ex.Message}");
        //    }
        //}
        public class result
        {
            public string message { get; set; }
            public string type { get; set; }
        }
        public async Task<bool> VerifyOTPAsync(string mobile, string otpNumber)
        {
            bool flag = false;

            try
            {
                // Construct the full URL with query parameters
                var baseUrl = "https://api.msg91.com/api/v5/otp";
                // Create a RestClient instance with the base URL
                var client = new RestClient(baseUrl);

                // Create a RestRequest instance with the endpoint and method
                var request = new RestRequest();
                request.AddParameter("otp", otpNumber);
                request.AddParameter("authkey", Environment.GetEnvironmentVariable("MSG91_AUTHKEY")); // API key from environment variable
                request.AddParameter("mobile", $"91{mobile}");
                request.AddParameter("otp_expiry", "5");

                // Send the request and get the response asynchronously
                var response = await client.ExecuteAsync(request);

                // Check if the StatusCode is 200 (OK)
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Deserialize the response content to dynamic
                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        var data = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

                        // Extract the 'message' and 'type' fields from the response
                        string? message = data["message"]?.ToString();
                        string? type = data["type"]?.ToString();

                        // Check if the type is "success"
                        if (type == "success")
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Response content is empty.");
                    }
                }
                else
                {
                    // Optionally handle non-200 responses
                    Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related exceptions
                Console.WriteLine($"Network Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other types of exceptions
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return flag;
        }
        //public bool VerifyOTP(string mobile, string otpNumber)
        //{
        //    bool flag = false;

        //    try
        //    {
        //        // Create a RestClient instance with the base URL
        //        var baseUrl = "https://api.msg91.com/api/v5/otp/verify";
        //        var client = new RestClient(baseUrl);

        //        // Create a RestRequest instance with the query parameters and method
        //        var request = new RestRequest(Method.GET);
        //        request.AddParameter("otp", otpNumber);
        //        request.AddParameter("authkey", "325791AwTEkoGFG5e8f6220P1");
        //        request.AddParameter("mobile", $"91{mobile}");
        //        request.AddParameter("otp_expiry", "5");

        //        // Send the request and get the response asynchronously
        //        var response = client.Execute(request);

        //        // Check if the StatusCode is 200 (OK)
        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            // Deserialize the response content to dynamic
        //            var data = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

        //            // Extract the 'message' and 'type' fields from the response
        //            string? message = data["message"]?.ToString();
        //            string? type = data["type"]?.ToString();

        //            // Check if the type is "success"
        //            if (type == "success")
        //            {
        //                flag = true;
        //            }
        //        }
        //        else
        //        {
        //            // Optionally handle non-200 responses
        //            Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle exceptions
        //        Console.WriteLine($"Exception: {ex.Message}");
        //    }

        //    return flag;
        //}
        public static long GetTokenExpirationTime(ClaimsPrincipal token)
        {
            var tokenExp = (token
                      .Claims
                      .Where(c => c.Type.Equals("exp"))
                      .FirstOrDefault())?.Value;
            var ticks = long.Parse(tokenExp);
            return ticks;
        }

        
        public static string Base64Encode(string text)
        {
            var textBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textBytes);
        }
        public static string Base64Decode(string base64)
        {
            var base64Bytes = System.Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(base64Bytes);
        }

    }
}