using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/productCategory")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public ProductCategoryController(IProductCategoryApplication productCategoryApplication) 
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductCatDTO>> GetById([FromRoute]int id)
        {
            var category = await _productCategoryApplication.GetByIdAsync(id);
            
            if (!category.IsSuccess)
            {
                return BadRequest(new ResponseError($"{category.Message}"));
            }

            if (category.Data == null) 
            {
                return NotFound(new ResponseError($"The product category id was not found."));
            }

            return Ok(category.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductCatDTO>>> GetAll()
        {
            var categories = await _productCategoryApplication.GetAllAsync();

            if (!categories.IsSuccess)
            {
                return BadRequest(new ResponseError(categories.Message));
            }

            return Ok(categories.Data);
        }
        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<ProductCatDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var categories = await _productCategoryApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!categories.IsSuccess)
            {
                return BadRequest(new ResponseError(categories.Message));
            }

            var metadata = new
            {
                categories.Data.TotalCount,
                categories.Data.PageSize,
                categories.Data.CurrentPage,
                categories.Data.HasNext,
                categories.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(categories.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<ProductCatDTO>>> GetAll([FromRoute]string name)
        {
            var categories = await _productCategoryApplication.GetAllTthatContainsNameAsync(name);

            if (!categories.IsSuccess)
            {
                return BadRequest(new ResponseError(categories.Message));
            }

            return Ok(categories.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCatCreateDTO obj)
        {
            var insert = await _productCategoryApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] ProductCatUpdateDTO obj)
        {
            var category = await _productCategoryApplication.GetByIdAsync(id);

            if (category.Data == null)
            {
                return NotFound(new ResponseError($"The product category id was not found."));
            }

            var update = await _productCategoryApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var category = await _productCategoryApplication.GetByIdAsync(id);

            if (category.Data == null)
            {
                return NotFound(new ResponseError($"The product category id was not found."));
            }

            var delete = await _productCategoryApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }
    }
}
