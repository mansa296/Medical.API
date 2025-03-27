using System.Security.Cryptography;
using System.Text;

namespace Medical.Infrastructure.Security
{
    /// <summary>
    /// The hashing helper class
    /// </summary>
    public class HashingHelper
    {
        /// <summary>
        /// Shas the 256 hash using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The string</returns>
        public static string SHA256Hash(string value)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        /// <summary>
        /// Describes whether verify hash
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="hashedValue">The hashed value</param>
        /// <returns>The bool</returns>
        public static bool VerifyHash(string value, string hashedValue)
            => string.Equals(SHA256Hash(value), hashedValue,StringComparison.OrdinalIgnoreCase);
    }
}
