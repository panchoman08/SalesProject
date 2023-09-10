using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/buyOrder")]
    public class BuyOrderController : ControllerBase
    {
        private readonly IBuyOrderApplication _buyOrderApplication;
        public BuyOrderController(IBuyOrderApplication buyOrderApplication) 
        {
            _buyOrderApplication = buyOrderApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuyOrderDTO>> GetById([FromRoute]int id)
        {
            var buyOrder = await _buyOrderApplication.GetByIdAsync(id);
            
            if (!buyOrder.IsSuccess)
            {
                return BadRequest(new ResponseError(buyOrder.Message));
            }

            if (buyOrder.Data == null)
            {
                return NotFound(new ResponseError("The buy order id was not found."));
            }

            return Ok(buyOrder.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BuyOrderDTO>> GetAll()
        {
            var buyOrder = await _buyOrderApplication.GetAllAsync();

            if (!buyOrder.IsSuccess)
            {
                return BadRequest(new ResponseError(buyOrder.Message));
            }

            return Ok(buyOrder.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<BuyOrderDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var buyOrders = await _buyOrderApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!buyOrders.IsSuccess)
            {
                return BadRequest(new ResponseError(buyOrders.Message));
            }

            var metadata = new
            {
                buyOrders.Data.TotalCount,
                buyOrders.Data.PageSize,
                buyOrders.Data.CurrentPage,
                buyOrders.Data.HasNext,
                buyOrders.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(buyOrders.Data);
        } 

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BuyOrderCreateDTO buyOrder)
        {
            var insert = await _buyOrderApplication.InsertAsync(buyOrder);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPost("toBuy/{id:int}")]
        public async Task<ActionResult> ConcludeBuyOrder([FromRoute]int id)
        {
            var buyOrder = await _buyOrderApplication.GetByIdAsync(id);

            if (buyOrder.Data == null)
            {
                return NotFound(new ResponseError("The buy order id was not found."));
            }

            var conclude = await _buyOrderApplication.GenerateBuyBasedOnBuyOrder(id);

            if (!conclude.IsSuccess)
            {
                return BadRequest(new ResponseError(conclude.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] BuyOrderUpdateDTO obj)
        {
            var buyOrder = await _buyOrderApplication.GetByIdAsync(id);

            if (buyOrder.Data == null)
            {
                return NotFound(new ResponseError("The buy order id was not found."));
            }

            var update = await _buyOrderApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var buyOrder = await _buyOrderApplication.GetByIdAsync(id);

            if (buyOrder.Data == null)
            {
                return NotFound(new ResponseError("The buy order id was not found."));
            }

            var delete = await _buyOrderApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
