using System.ComponentModel;

namespace Medical.Common.Enums
{
    /// <summary>
    /// The application type enum enum
    /// </summary>
    public enum ApplicationTypeEnum
    {
        /// <summary>
        /// The timing application type enum
        /// </summary>
        [Description("Cloud Migration Timing")]
        Timing,
        /// <summary>
        /// The cloud migration strategy application type enum
        /// </summary>
        [Description("Cloud Migration Strategy")]
        CloudMigrationStrategy,
        /// <summary>
        /// The cloud readiness application type enum
        /// </summary>
        [Description("Cloud Readiness")]
        CloudReadiness,
        /// <summary>
        /// The cloud benefit application type enum
        /// </summary>
        [Description("Cloud Benefit")]
        CloudBenefit,
        /// <summary>
        /// The migration risk application type enum
        /// </summary>
        [Description("Migration Risk")]
        MigrationRisk,
        /// <summary>
        /// The without value application type enum
        /// </summary>
        [Description("Without value")]
        WithoutValue,
        /// <summary>
        /// The business criticality application type enum
        /// </summary>
        [Description("Business Criticality")]
        BusinessCriticality,
        /// <summary>
        /// The cloud provider application type enum
        /// </summary>
        [Description("Cloud Providers")]
        CloudProvider,
        /// <summary>
        /// The migration status application type enum
        /// </summary>
        [Description("Migration Status")]
        MigrationStatus
    }
}
