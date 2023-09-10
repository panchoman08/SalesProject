using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/productMeasure")]
    public class ProductMeasureController : ControllerBase
    {
        private readonly IProductMeasureApplication _productMeasureApplication;

        public ProductMeasureController(IProductMeasureApplication productMeasureApplication)
        {
            _productMeasureApplication = productMeasureApplication; 
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductMeasureDTO>> GetById([FromRoute] int id)
        {
            var measure = await _productMeasureApplication.GetByIdAsync(id);

            if (!measure.IsSuccess)
            {
                return BadRequest(new ResponseError($"{measure.Message}"));
            }

            if (measure.Data == null)
            {
                return NotFound(new ResponseError("The product measure id was not found."));
            }

            return Ok(measure.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ProductMeasureDTO>> GetAll()
        {
            var measures = await _productMeasureApplication.GetAllAsync();

            if (!measures.IsSuccess)
            {
                return BadRequest(new ResponseError($"{measures.Message}"));
            }

            return Ok(measures.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<ProductMeasureDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var measures = await _productMeasureApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!measures.IsSuccess)
            {
                return BadRequest(new ResponseError(measures.Message));
            }

            var metadata = new
            {
                measures.Data.TotalCount,
                measures.Data.PageSize,
                measures.Data.CurrentPage,
                measures.Data.HasNext,
                measures.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(measures.Data);
        } 

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<ProductMeasureDTO>> GetAll([FromRoute] string name)
        {
            var measures = await _productMeasureApplication.GetAllTthatContainsNameAsync(name);

            if (!measures.IsSuccess)
            {
                return BadRequest(new ResponseError($"{measures.Message}"));
            }

            return Ok(measures.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductMeasureCreateDTO obj)
        {
            var insert = await _productMeasureApplication.InsertAsync(obj);

            if (!insert.IsSuccess) 
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] ProductMeasureUpdateDTO obj)
        {
            var measure = await _productMeasureApplication.GetByIdAsync(id);

            if (measure.Data == null)
            {
                return NotFound(new ResponseError("The product measure id was not found."));
            }

            var update = await _productMeasureApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var measure = await _productMeasureApplication.GetByIdAsync(id);

            if (measure.Data == null)
            {
                return NotFound(new ResponseError("The product measure id was not found."));
            }

            var delete = await _productMeasureApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
