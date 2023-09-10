using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale.sale;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/sale")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleApplication _saleApplication;

        public SaleController(ISaleApplication saleApplication)
        {
            _saleApplication= saleApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SaleDTO>> GetById([FromRoute]int id)
        {
            var sale = await _saleApplication.GetByIdAsync(id);

            if (!sale.IsSuccess)
            {
                return BadRequest(new ResponseError(sale.Message));
            }

            if (sale.Data == null)
            {
                return NotFound(new ResponseError("The sale id was not found."));
            }

            return Ok(sale.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetAll()
        {
            var sale = await _saleApplication.GetAllAsync();

            if (!sale.IsSuccess)
            {
                return BadRequest(new ResponseError(sale.Message));
            }

            return Ok(sale.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<SaleDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var sales = await _saleApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!sales.IsSuccess)
            {
                return BadRequest(new ResponseError(sales.Message));
            }

            var metadata = new
            {
                sales.Data.TotalCount,
                sales.Data.PageSize,
                sales.Data.CurrentPage,
                sales.Data.HasNext,
                sales.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(sales.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]SaleCreateDTO obj)
        {
            var insert = await _saleApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] SaleUpdateDTO obj)
        {
            var sale = await _saleApplication.GetByIdAsync(id);

            if (sale.Data == null)
            {
                return NotFound(new ResponseError("The sale id was not found."));
            }

            var update = await _saleApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var sale = await _saleApplication.GetByIdAsync(id);

            if (sale.Data == null)
            {
                return NotFound(new ResponseError("The sale id was not found."));
            }

            var delete = await _saleApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
