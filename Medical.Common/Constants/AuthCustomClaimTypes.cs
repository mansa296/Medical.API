namespace Medical.Common.Constants
{
    /// <summary>
    /// The auth custom claim types class
    /// </summary>
    public static class AuthCustomClaimTypes
    {
        /// <summary>
        /// The country claim type
        /// </summary>
        public const string CountryClaimType = "ctry";
        /// <summary>
        /// The company claim type
        /// </summary>
        public const string CompanyClaimType = "companyname";
        /// <summary>
        /// The company claim type
        /// </summary>
        public const string givenname = "givenname";
        /// <summary>
        /// The company claim type
        /// </summary>
        public const string surname = "surname";
        /// <summary>
        /// The company claim type
        /// </summary>
        public const string SecurityGroups = "groups";

        /// <summary>
        /// The memberfirm claim type
        /// </summary>

        private static string _MemberfirmClaimType;

        static AuthCustomClaimTypes()
        {
            _MemberfirmClaimType = string.Empty;
        }
        public static void SetMemberfirmClaimType(string MemberfirmClaimType)
        {
            _MemberfirmClaimType = MemberfirmClaimType;
        }
        public static string GetMemberfirmClaimType()
        {
            return _MemberfirmClaimType;
        }
    }
}
