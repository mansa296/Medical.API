using System.ComponentModel;

namespace Medical.Common.Enums
{
    /// <summary>
    /// The application business complexity type enum enum
    /// </summary>
    public enum ApplicationBusinessComplexityTypeEnum
    {
        /// <summary>
        /// The low application business complexity type enum
        /// </summary>
        [Description("Low")]
        Low,
        /// <summary>
        /// The medium application business complexity type enum
        /// </summary>
        [Description("Medium")]
        Medium,
        /// <summary>
        /// The high application business complexity type enum
        /// </summary>
        [Description("High")]
        High,
        /// <summary>
        /// The without value application business complexity type enum
        /// </summary>
        [Description("Without Value")]
        WithoutValue
    }
}
