using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Common.Constants
{
    public static  class UtilityContants
    {
        /// <summary>
        /// The application asset type
        /// </summary>
        public const string DataAccessConnectionString = "DataAccess:ConnectionString";
        /// <summary>
        /// The application asset type
        /// </summary>
        public const string DataAccess = "DataAccess";
        
       
        public const string FetchSecurityGroups = "EXEC prc_GetAllBusUnitSecurityGroups";
        public const string GetUserDetails = "Exec prc_GetUserDetails @Email";
        public const string AssignUserBusinessUnit = "EXEC usr.prc_AssignUserBusinessUnit @IsGlobal, @UserId";
        public const string MapUserBusinessUnit = "EXEC usr.prc_MapUserBusinessUnit @UserBusinessUnitJson";
        public const string CheckAuthorization = "EXEC prc_Authorization @email, @businessUnitId";

        /// <summary>
        /// The application asset type
        /// </summary>
        public const string targetArchitectureCustomlineitem = "FixedPriceLineItem";
        
    }
}
