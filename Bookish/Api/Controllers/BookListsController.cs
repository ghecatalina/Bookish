using Api.Dto;
using Application.Users.Commands.AddBookToList;
using Application.Users.Queries.GetBookList;
using Application.Users.Queries.GetIfInAnyList;
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
        public async Task<IActionResult> GetReadList(Guid userId)
        {
            var query = new GetReadListQuery { Id = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<BookDto>>(result.Books);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("ifany")]
        public async Task<IActionResult> GetIfInAnyList([FromBody] BookIdUserIdDto dto)
        {
            var query = new GetIfInAnyListQuery() { BookId = dto.BookId, UserId = dto.UserId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<ListTypeDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("addbook")]
        public async Task<IActionResult> AddBookToList([FromBody] AddToBookListDto dto)
        {
            var query = _mapper.Map<AddBookToListCommand>(dto);
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<ListTypeDto>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("getList")]
        public async Task<IActionResult> GetBookList([FromBody] GetBookListDto dto)
        {
            var query = new GetBookListQuery() { UserId = dto.UserId, ListType = dto.ListType };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<ICollection<BookGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
