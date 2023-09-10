using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.min_max;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/minMaxProductUnits")]
    public class MinMaxProductUnitsController : ControllerBase
    {
        private readonly IMinMaxProductUnitsApplication _minMaxProductUnitsApplication;
        public  MinMaxProductUnitsController(IMinMaxProductUnitsApplication minMaxProductUnitsApplication) 
        {
            _minMaxProductUnitsApplication = minMaxProductUnitsApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MinMaxProductUnitsDTO>> GetById([FromRoute] int id)
        {
            var minMaxProd = await _minMaxProductUnitsApplication.GetByIdAsync(id);

            if (!minMaxProd.IsSuccess)
            {
                return BadRequest(new ResponseError(minMaxProd.Message));
            }

            if (minMaxProd.Data == null)
            {
                return NotFound(new ResponseError($"The min max product id was not found."));
            }

            return Ok(minMaxProd.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MinMaxProductUnitsDTO>>> GetAll()
        {
            var minMaxProducts = await _minMaxProductUnitsApplication.GetAllAsync();

            if (!minMaxProducts.IsSuccess)
            {
                return BadRequest(new ResponseError(minMaxProducts.Message));
            }

            return Ok(minMaxProducts.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<MinMaxProductUnitsDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var minMaxProd = await _minMaxProductUnitsApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!minMaxProd.IsSuccess)
            {
                return BadRequest(new ResponseError(minMaxProd.Message));
            }

            var metadata = new 
            { 
                minMaxProd.Data.TotalCount,
                minMaxProd.Data.PageSize,
                minMaxProd.Data.CurrentPage,
                minMaxProd.Data.HasNext,
                minMaxProd.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(minMaxProd.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MinMaxProductUnitsCreateDTO obj)
        {
            var insert = await _minMaxProductUnitsApplication.InsertAsync(obj);
            
            if(!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] MinMaxProductUnitsUpdateDTO obj)
        {
            var minMaxProduct = await _minMaxProductUnitsApplication.GetByIdAsync(id);

            if (minMaxProduct.Data == null)
            {
                return NotFound(new ResponseError("The minimun and maximum product id was not found."));
            }

            var update = await _minMaxProductUnitsApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var minMaxProduct = await _minMaxProductUnitsApplication.GetByIdAsync(id);

            if (minMaxProduct.Data == null)
            {
                return NotFound(new ResponseError("The minimun and maximum product id was not found."));
            }

            var delete = await _minMaxProductUnitsApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }

}
