using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_order.sale_order;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/saleOrder")]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderApplication _saleOrderApplication;

        public SaleOrderController(ISaleOrderApplication saleOrderApplication)
        {
            _saleOrderApplication = saleOrderApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SaleOrderDTO>> GetById([FromRoute]int id)
        {
            var saleOrder = await _saleOrderApplication.GetByIdAsync(id);

            if (!saleOrder.IsSuccess)
            {
                return BadRequest(new ResponseError(saleOrder.Message));
            }

            if (saleOrder.Data == null)
            {
                return NotFound(new ResponseError("The sale order id was not found."));
            }

            return Ok(saleOrder.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SaleOrderDTO>>> GetAll()
        {
            var saleOrders = await _saleOrderApplication.GetAllAsync();

            if (!saleOrders.IsSuccess)
            {
                return BadRequest(new ResponseError(saleOrders.Message));
            }

            return Ok(saleOrders.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<SaleOrderDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var saleOrders = await _saleOrderApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!saleOrders.IsSuccess)
            {
                return BadRequest(new ResponseError(saleOrders.Message));
            }

            var metadata = new
            {
                saleOrders.Data.TotalCount,
                saleOrders.Data.PageSize,
                saleOrders.Data.CurrentPage,
                saleOrders.Data.HasNext,
                saleOrders.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(saleOrders.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]SaleOrderCreateDTO obj)
        {
            var insert = await _saleOrderApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPost("toSale/{id:int}")]
        public async Task<ActionResult> Post([FromRoute] int id)
        {
            var insert = await _saleOrderApplication.GenerateSaleBasedOnSaleOrder(id);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]SaleOrderUpdateDTO obj)
        {
            var saleOrder = await _saleOrderApplication.GetByIdAsync(id);

            if (saleOrder.Data == null)
            {
                return NotFound(new ResponseError("The sale order id was not found."));
            }

            var update = await _saleOrderApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var saleOrder = await _saleOrderApplication.GetByIdAsync(id);

            if (saleOrder.Data == null)
            {
                return NotFound(new ResponseError("The sale order id was not found."));
            }

            var update = await _saleOrderApplication.DeleteAsync(id);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }
    }
}
