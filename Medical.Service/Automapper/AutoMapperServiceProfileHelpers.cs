using Medical.Data.EF.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System.Globalization;
using System.Text.Json.Nodes;

namespace Medical.Service.Automapper
{
    /// <summary>
    /// The auto mapper service profile helpers class
    /// </summary>
    public class AutoMapperServiceProfileHelpers
    {
        /// <summary>
        /// Gets the application name property using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The string</returns>
        public static string GetApplicationNameProperty(IList<Property>? properties, string propertyName)
        {
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            return property is null ? "Unnamed Asset" : property.Value;
        }

        /// <summary>
        /// Gets the application discovery property using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The string</returns>
        public static string GetApplicationDiscoveryProperty(IList<Property>? properties, string propertyName)
        {
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            return property is null ? string.Empty : property.Value;
        }

        /// <summary>
        /// Describes whether get application discovery bool property
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The bool</returns>
        public static bool GetApplicationDiscoveryBoolProperty(IList<Property>? properties, string propertyName)
        {
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            return property is null ? false : bool.Parse(property.Value);
        }

        /// <summary>
        /// Gets the application discovery nullable property using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The string</returns>
        public static string? GetApplicationDiscoveryNullableProperty(IList<Property>? properties, string propertyName)
        {
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            return property is null ? null : property.Value;
        }

        /// <summary>
        /// Gets the application discovery number property using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The double</returns>
        public static double GetApplicationDiscoveryNumberProperty(IList<Property>? properties, string propertyName)
        {
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            return property is null ? 0 : double.Parse(property.Value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the application discovery multi value property using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <param name="propertyName">The property name</param>
        /// <returns>The list</returns>
        public static List<string> GetApplicationDiscoveryMultiValueProperty(IList<Property>? properties, string propertyName)
        {
            var list = new List<string>();
            var property = properties?.FirstOrDefault(x => x.Name.Equals(propertyName));
            if (property is null)
            {
                return list;
            }

            list = new JsonArray(property.Value).Where(x => x is not null).Select(x => x.GetValue<string>().Split("\"")[1]).ToList();

            return list;
        }

        /// <summary>
        /// Gets the comma separated string values using the specified values
        /// </summary>
        /// <param name="values">The values</param>
        /// <returns>The list</returns>
        public static List<string> GetCommaSeparatedStringValues(string? values)
        {
            var list = new List<string>();

            if (string.IsNullOrEmpty(values))
            {
                return list;
            }
             
            if (values.Contains('\u002C'))
            {
                var commaSeparatedValues = values.Split('\u002C');
                list.AddRange(commaSeparatedValues);
            }
            else
            {
                list.Add(values);
            }

            return list;
        }

        /// <summary>
        /// Gets the semicolon separated string values using the specified values
        /// </summary>
        /// <param name="values">The values</param>
        /// <returns>The list</returns>
        public static List<string> GetSemicolonSeparatedStringValues(string? values)
        {
            var list = new List<string>();

            if (string.IsNullOrEmpty(values))
            {
                return list;
            }

            if (values.Contains('\u003B'))
            {
                var semicolonSeparatedValues = values.Split('\u003B');
                list.AddRange(semicolonSeparatedValues);
            }
            else
            {
                list.Add(values);
            }

            return list;
        }

        /// <summary>
        /// Gets the string normalized value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The string</returns>
        public static string GetStringNormalizedValue(string? value)
        {
            return value ?? string.Empty;
        }

        /// <summary>
        /// Gets the base 64 file content using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The base 64string</returns>
        public static string GetBase64FileContent(IFormFile file)
        {
            if (file.Length == 0)
            {
                return string.Empty;
            }

            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);

            var fileBytes = memoryStream.ToArray();
            var base64string = Convert.ToBase64String(fileBytes);

            return base64string;
        }

        /// <summary>
        /// Gets the file extension using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The string</returns>
        public static string GetMimeType(IFormFile file)
        {
            string? contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out contentType);
            return contentType ?? "application/octet-stream";
        }
    }
}