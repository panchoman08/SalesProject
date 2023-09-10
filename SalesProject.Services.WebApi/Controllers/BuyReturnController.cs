using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.buy_return.buy_return;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/buyReturn")]
    public class BuyReturnController : ControllerBase
    {
        private readonly IBuyReturnApplication _buyReturnApplication;

        public BuyReturnController(IBuyReturnApplication buyReturnApplication)
        {
            _buyReturnApplication = buyReturnApplication;    
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuyReturnDTO>> GetById([FromRoute]int id)
        {
            var buyReturn = await _buyReturnApplication.GetByIdAsync(id);

            if (!buyReturn.IsSuccess)
            {
                return BadRequest(new ResponseError($"{buyReturn.Message}"));
            }

            if (buyReturn.Data == null)
            {
                return NotFound(new ResponseError("The buy return id was not found."));
            }

            return Ok(buyReturn.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<BuyReturnDTO>>> GetAll()
        {
            var buyReturns = await _buyReturnApplication.GetAllAsync();

            if (!buyReturns.IsSuccess)
            {
                return BadRequest(new ResponseError($"{buyReturns.Message}"));
            }

            return Ok(buyReturns.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<BuyReturnDTO>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var buyReturns = await _buyReturnApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if(!buyReturns.IsSuccess) 
            {
                return BadRequest(new ResponseError(buyReturns.Message));
            }

            var metadata = new
            {
                buyReturns.Data.TotalCount,
                buyReturns.Data.PageSize,
                buyReturns.Data.CurrentPage,
                buyReturns.Data.HasNext,
                buyReturns.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(buyReturns.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BuyReturnCreateDTO obj)
        {
            var insert = await _buyReturnApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]BuyReturnUpdateDTO obj)
        {
            var buyReturn = await _buyReturnApplication.GetByIdAsync(id);

            if (buyReturn.Data == null)
            {
                return NotFound(new ResponseError("The buy return id was not found."));
            }

            var update = await _buyReturnApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var buyReturn = await _buyReturnApplication.GetByIdAsync(id);

            if (buyReturn.Data == null)
            {
                return NotFound(new ResponseError("The buy return id was not found."));
            }

            var delete = await _buyReturnApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
