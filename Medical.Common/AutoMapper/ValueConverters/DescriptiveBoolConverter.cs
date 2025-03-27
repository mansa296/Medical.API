using AutoMapper;

namespace Medical.Common.AutoMapper.ValueConverters
{
    /// <summary>
    /// The descriptive bool converter class
    /// </summary>
    /// <seealso cref="IValueConverter{string, bool}"/>
    public class DescriptiveBoolConverter : IValueConverter<string, bool>
    {
        /// <summary>
        /// Describes whether this instance convert
        /// </summary>
        /// <param name="boolString">The bool string</param>
        /// <param name="context">The context</param>
        /// <returns>The bool</returns>
        public bool Convert(string boolString, ResolutionContext context)
        {
            return string.Equals(boolString, "Yes", StringComparison.OrdinalIgnoreCase);
        }
    }
}
