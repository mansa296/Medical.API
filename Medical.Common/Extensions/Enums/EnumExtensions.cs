using System.ComponentModel;

namespace Medical.Common.Extensions.Enums
{
    /// <summary>
    /// The enum extensions class
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the description using the specified enum value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="enumValue">The enum value</param>
        /// <returns>The description</returns>
        public static string GetDescription<T>(this Enum enumValue)
            where T : Enum, IConvertible
        {
            if (!typeof(T).IsEnum)
                return String.Empty;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}
