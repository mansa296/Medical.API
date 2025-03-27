using System.ComponentModel;

namespace Medical.Common.Enums
{
    /// <summary>
    /// The migration file type enum enum
    /// </summary>
    public enum MigrationFileTypeEnum
    {
        /// <summary>
        /// The migration status file type enum
        /// </summary>
        [Description("Status")]
        Status,
        /// <summary>
        /// The target architecture file type enum
        /// </summary>
        [Description("Target Architecture")]
        TargetArchitecture,
        /// <summary>
        /// The unit test file type enum
        /// </summary>
        [Description("Unit Test")]
        UnitTest,
        /// <summary>
        /// The integration test file type enum
        /// </summary>
        [Description("Integration Test")]
        IntegrationTest,
        /// <summary>
        /// The functional test file type enum
        /// </summary>
        [Description("Functional Test")]
        FunctionalTest,
        /// <summary>
        /// The regression test file type enum
        /// </summary>
        [Description("Regression Test")]
        RegressionTest,
        /// <summary>
        /// The performance test file type enum
        /// </summary>
        [Description("Performance Test")]
        PerformanceTest
    }
}