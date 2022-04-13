using Api.Dto;
using Application.Users.Queries.GetRegularUserById;
using Application.Users.Queries.LoginUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var query = new GetRegularUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<RegularUserGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
