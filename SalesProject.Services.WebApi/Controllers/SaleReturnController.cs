using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_return.sale_return;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/saleReturn")]
    public class SaleReturnController : Controller
    {
        private readonly ISaleReturnApplication _saleReturnApplication;

        public SaleReturnController(ISaleReturnApplication saleReturnApplication)
        {
            _saleReturnApplication = saleReturnApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SaleReturnDTO>> Get([FromRoute]int id)
        {
            var saleReturn = await _saleReturnApplication.GetByIdAsync(id);

            if (!saleReturn.IsSuccess)
            {
                return BadRequest(new ResponseError($"{saleReturn.Message}"));
            }

            if (saleReturn.Data == null)
            {
                return NotFound(new ResponseError("The sale return id was not found."));
            }

            return Ok(saleReturn.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleReturnDTO>>> GetAll()
        {
            var saleReturn = await _saleReturnApplication.GetAllAsync();

            if (!saleReturn.IsSuccess)
            {
                return BadRequest(new ResponseError($"{saleReturn.Message}"));
            }

            return Ok(saleReturn.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<SaleReturnDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var saleReturns = await _saleReturnApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!saleReturns.IsSuccess)
            {
                return BadRequest(new ResponseError(saleReturns.Message));
            }

            var metadata = new
            {
                saleReturns.Data.TotalCount,
                saleReturns.Data.PageSize,
                saleReturns.Data.CurrentPage,
                saleReturns.Data.HasNext,
                saleReturns.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(saleReturns.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]SaleReturnCreateDTO obj)
        {
            var insert = await _saleReturnApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] SaleReturnUpdateDTO obj)
        {
            var saleReturn = await _saleReturnApplication.GetByIdAsync(id);

            if (saleReturn.Data == null)
            {
                return NotFound(new ResponseError("The sale return id was not found."));
            }

            var update = await _saleReturnApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var saleReturn = await _saleReturnApplication.GetByIdAsync(id);

            if (saleReturn.Data == null)
            {
                return NotFound(new ResponseError("The sale return id was not found."));
            }

            var delete = await _saleReturnApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }

    }
}
