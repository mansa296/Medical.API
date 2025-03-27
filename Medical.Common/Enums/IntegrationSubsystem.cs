using System.ComponentModel;

namespace Medical.Common.Enums
{
    /// <summary>
    /// The integration subsystem enum
    /// </summary>
    public enum IntegrationSubsystem
    {
        /// <summary>
        /// The txture integration subsystem
        /// </summary>
        [Description("Txture")]
        Txture = 1,
        /// <summary>
        /// The matilda integration subsystem
        /// </summary>
        [Description("Matilda")]
        Matilda
    }
}
