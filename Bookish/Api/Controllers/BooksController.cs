using Api.Dto;
using Application.Books.Commands.CreateBook;
using Application.Books.Queries.GetBookById;
using Application.Books.Queries.GetBooks;
using Application.Users.Queries.GetReadList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BooksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookPutPostDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateBookCommand>(book);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<BookGetDto>(created);

            return CreatedAtAction(nameof(GetBookById), new { bookId = created.Id }, dto);
        }


        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetReadList(int userId)
        {
            var query = new  GetBookByIdQuery { Id = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<BookDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetBooksQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<BookDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var query = new GetBookByIdQuery { Id = bookId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<BookGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
