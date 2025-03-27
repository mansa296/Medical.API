using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Options.Security
{
    public class AzureStorage
    {
        public String BlobConnectionString { get; set; }
        public String BlobContainerName { get; set; }
        public int SharedAccessExpiryTime { get; set; }
    }
}
