using Api.Dto;
using Application.Users.Queries.GetReadList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookListsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BookListsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("readlist/{userId}")]
        public async Task<IActionResult> GetReadList(int userId)
        {
            var query = new GetReadListQuery { Id = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<BookDto>>(result.Books);
            return Ok(mappedResult);
        }
    }
}
