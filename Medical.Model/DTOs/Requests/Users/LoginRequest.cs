using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.DTOs.Requests.Users
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class OPTVerifyRequest
    {
        public string OTP { get; set; }
        public string Token { get; set; }
    }
}
