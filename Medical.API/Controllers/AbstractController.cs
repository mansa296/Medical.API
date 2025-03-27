using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Medical.API.Controllers
{
    /// <summary>
    /// The abstract controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    public class AbstractController : ControllerBase
    {
        /// <summary>
        /// The mediator
        /// </summary>
        protected readonly IMediator _mediator;
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractController"/> class
        /// </summary>
        /// <param name="mediator">The mediator</param>
        /// <param name="mapper">The mapper</param>
        public AbstractController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
