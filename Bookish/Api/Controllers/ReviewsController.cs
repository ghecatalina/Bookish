using Api.Dto;
using Application.Reviews.Commands.CreateReview;
using Application.Reviews.Commands.DeleteReview;
using Application.Reviews.Commands.UpdateReview;
using Application.Reviews.Queries.GetNoOfReviews;
using Application.Reviews.Queries.GetReviewById;
using Application.Reviews.Queries.GetReviewByUserAndBook;
using Application.Reviews.Queries.GetReviewsByBook;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ReviewsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewPutPostDto review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateReviewCommand>(review);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<ReviewGetDto>(created);

            return CreatedAtAction(nameof(GetReviewById), new { reviewId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var query = new GetReviewByIdQuery { Id = reviewId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<ReviewGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("ratings/{bookId}")]
        public async Task<IActionResult> GetRatingNo(int bookId)
        {
            var query = new GetNoOfReviewsQuery() { Id = bookId };
            var result = await _mediator.Send(query);

            var mappedResult = _mapper.Map<List<RatingGroupDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("userBook")]
        public async Task<IActionResult> GetReviewByBookAndUser(int bookId, Guid userId)
        {
            var query = new GetReviewByUserAndBookQuery() { BookId = bookId, UserId = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<ReviewGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("withoutCurrUser")]
        public async Task<IActionResult> GetReviewsWithoutCurrUser(int bookId, Guid userId)
        {
            var query = new GetReviewsByBookQuery { BookId = bookId, UserId = userId };
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<ReviewGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewPutPostDto review)
        {
            var command = _mapper.Map<UpdateReviewCommand>(review);
            command.Id = id;
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteReviewCommand { Id = id };
            var result = await _mediator.Send(command);
            return NoContent();
        }
    }
}
