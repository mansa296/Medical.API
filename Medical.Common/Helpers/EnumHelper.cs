using System.ComponentModel;

namespace Medical.Common.Helpers
{
    /// <summary>
    /// The enum helper class
    /// </summary>
    public static class EnumHelper
#pragma warning disable CS8603 // Possible null reference return.
    {
        /// <summary>
        /// Returns value of <see cref="DescriptionAttribute"/> for passed
        /// <typeparamref name="T"/> <paramref name="value"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : struct, IConvertible
        {
            var desc = GetText(value);

            if (string.IsNullOrWhiteSpace(desc))
                return null;

            var info = value.GetType().GetField(desc);

            if (info != null)
            {
                var attrs = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    desc = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return desc;
        }

        /// <summary>
        /// Returns text value for passed
        /// <typeparamref name="T"/> <paramref name="value"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetText<T>(this T value) where T : struct, IConvertible
        {
            if (IsValid(value))
            {
                return value.ToString() ?? null;
            }
            return null;
        }

        /// <summary>
        /// Describes whether is valid
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The bool</returns>
        private static bool IsValid<T>(this T value)
        {
            return typeof(T).IsEnum;
        }
    }
#pragma warning disable CS8603 // Possible null reference return.
}
