using System.Text.Json;

namespace Medical.Common.Extensions.JSON
{
    /// <summary>
    /// The json string extensions class
    /// </summary>
    public static class JsonStringExtensions
    {
        /// <summary>
        /// Describes whether try deserialize
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="json">The json</param>
        /// <param name="result">The result</param>
        /// <returns>The bool</returns>
        public static bool TryDeserialize<T>(this string? json, out T result)
        {
            try
            {
                result = JsonSerializer.Deserialize<T>(json);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }

        /// <summary>
        /// Deserializes the nullable using the specified json
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="json">The json</param>
        /// <returns>The</returns>
        public static T? DeserializeNullable<T>(this string? json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return default;
            }
        }
    }
}
