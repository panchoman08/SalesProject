using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/buy")]
    public class BuyController : ControllerBase
    {
        private readonly IBuyApplication _buyApplication;
        public BuyController(IBuyApplication buyApplication) 
        {
            _buyApplication= buyApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BuyDTO>> GetById([FromRoute]int id)
        {
            var buy = await _buyApplication.GetByIdAsync(id);

            if (!buy.IsSuccess)
            {
                return BadRequest(new ResponseError(buy.Message));
            }

            if (buy.Data == null)
            {
                return NotFound(new ResponseError("The buy id was not found."));
            }

            return Ok(buy.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<BuyDTO>> GetAll()
        {
            var buys = await _buyApplication.GetAllAsync();

            if (!buys.IsSuccess)
            {
                return BadRequest(new ResponseError(buys.Message));
            }

            return Ok(buys.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var buys = await _buyApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!buys.IsSuccess)
            {
                return BadRequest(new ResponseError(buys.Message));
            }

            var metadata = new
            {
                buys.Data.TotalCount,
                buys.Data.PageSize,
                buys.Data.CurrentPage,
                buys.Data.HasNext,
                buys.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(buys.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]BuyCreateDTO obj)
        {
            var insert = await _buyApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] BuyUpdateDTO obj)
        {
            var buy = await _buyApplication.GetByIdAsync(id);

            if (buy.Data == null)
            {
                return NotFound(new ResponseError("The buy id was not found."));
            }

            var update = await _buyApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var buy = await _buyApplication.GetByIdAsync(id);

            if (buy.Data == null)
            {
                return NotFound(new ResponseError("The buy id was not found."));
            }

            var delete = await _buyApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
