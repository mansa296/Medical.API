using AutoMapper;
using Medical.Model.DTOs.Responses;
using Medical.Repository.CssConfigRespository;

namespace Medical.Service.CssConfig
{
    public  class CssConfigService: ICssConfigService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper _mapper;
        /// <summary>
        /// The ef repository adapter
        /// </summary>
        protected readonly ICssConfigRespository _cssConfigRespositopry;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryService"/> class
        /// </summary>
        /// <param name="mapper">The mapper</param>
        /// <param name="efRepositoryAdapter">The ef repository adapter</param>
        public CssConfigService
        (
            IMapper mapper,
            ICssConfigRespository cssConfigRespositopry
        )
        {
            _mapper = mapper;
            _cssConfigRespositopry= cssConfigRespositopry;
        }

        
    }
}
