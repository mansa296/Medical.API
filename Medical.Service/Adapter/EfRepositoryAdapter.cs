using Medical.Common.Constants;
using Medical.Data.EF.Domain;
using Medical.Data.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Medical.Service.Adapter
{
    /// <summary>
    /// The ef repository adapter class
    /// </summary>
    /// <seealso cref="IEfRepositoryAdapter"/>
    public class EfRepositoryAdapter : IEfRepositoryAdapter
    {
        /// <summary>
        /// The link repository
        /// </summary>
        protected readonly IEFRepository<Link> _linkRepository;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepositoryAdapter"/> class
        /// </summary>
        /// <param name="jsonReportRepository">The json report repository</param>
        /// <param name="linkRepository">The link repository</param>
        /// <param name="assetRepository">The asset repository</param>
        public EfRepositoryAdapter
        (
            IEFRepository<Link> linkRepository
          )
        {
            _linkRepository = linkRepository;
            
        }

        
    }
}