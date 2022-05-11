using Api.Dto;
using Application.Categories.Commands.AddCategory;
using Application.Categories.Queries.GetAllCategories;
using Application.Categories.Queries.GetCategoryById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryPutPostDto category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<AddCategoryCommand>(category);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<CategoryGetDto>(created);

            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var query = new GetCategoryByIdQuery { Id = categoryId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<CategoryGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<CategoryGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
