using Api.Dto;
using Application.Users.Queries.GetUserById;
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
        public async Task<IActionResult> GetById(Guid userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserWithBookListsDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("image/{userId}")]
        public async Task<IActionResult> GetProfileImage(Guid userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ProfilePictureDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("info/{userId}")]
        public async Task<IActionResult> GetUserInfo(Guid userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<UserInfoDto>(result);
            return Ok(mappedResult);
        }
    }
}
