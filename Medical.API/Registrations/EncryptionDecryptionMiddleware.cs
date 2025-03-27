using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography;
using System.Text;

namespace Medical.API.Registrations
{
    public class EncryptionDecryptionMiddleware
    {
        
        private readonly RequestDelegate _next;

        public EncryptionDecryptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var a = httpContext.Request.QueryString.Value.Substring(1);
            if (httpContext.Request.QueryString.HasValue)
            {
                string decryptedString = DecryptString(httpContext.Request.QueryString.Value.Substring(1));
                httpContext.Request.QueryString = new QueryString($"?{decryptedString}");
            }
            await _next(httpContext);
            await httpContext.Request.Body.DisposeAsync();
           // await httpContext.Response.Body.DisposeAsync();
        }
      
        private string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}
