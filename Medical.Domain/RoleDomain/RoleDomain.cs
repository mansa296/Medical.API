using AutoMapper;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Roles;
using Medical.Repository.RoleRepository;

namespace Medical.Domain.RoleDomain
{
    /// <summary>
    /// The role domain class
    /// </summary>
    /// <seealso cref="IRoleDomain"/>
    public class RoleDomain : IRoleDomain
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDomain"/> class
        /// </summary>
        /// <param name="mapper">The mapper</param>
        /// <param name="roleRepository">The role repository</param>
        public RoleDomain
        (
            IMapper mapper,
            IRoleRepository roleRepository
        )
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a command response of i enumerable role response</returns>
        public async Task<CommandResponse<IEnumerable<RoleResponse>>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            if (roles is not null)
            {
                var response = _mapper.Map<IEnumerable<RoleResponse>>(roles);
                return CommandResponse<IEnumerable<RoleResponse>>.Succeeded(response);
            }

            return CommandResponse<IEnumerable<RoleResponse>>.Failed();
        }
    }
}
