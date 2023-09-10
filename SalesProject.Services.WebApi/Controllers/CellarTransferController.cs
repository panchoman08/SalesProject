using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/cellarTransfer")]
    public class CellarTransferController : ControllerBase
    {

        public readonly ICellarTransferApplication _cellarTransferApplication;

        public CellarTransferController(ICellarTransferApplication cellarTransferApplication)
        {
            _cellarTransferApplication = cellarTransferApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarTransferDTO>> GetById([FromRoute] int id)
        {
            var cellarTransfer = await _cellarTransferApplication.GetByIdAsync(id);

            if (!cellarTransfer.IsSuccess)
            {
                return BadRequest(new ResponseError(cellarTransfer.Message));
            }

            if (cellarTransfer.Data == null)
            {
                return NotFound(new ResponseError($"The cellar transfer id was not found."));
            }

            return Ok(cellarTransfer.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CellarTransferDTO>>> GetAll()
        {
            var cellarTransfers = await _cellarTransferApplication.GetAllAsync();

            if (!cellarTransfers.IsSuccess)
            {
                return BadRequest(new ResponseError($"{cellarTransfers.Message}"));
            }

            return Ok(cellarTransfers.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<CellarTransferDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var cellarTransfers = await _cellarTransferApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!cellarTransfers.IsSuccess)
            {
                return BadRequest(new ResponseError(cellarTransfers.Message));
            }

            var metadata = new
            {
                cellarTransfers.Data.TotalCount,
                cellarTransfers.Data.PageSize,
                cellarTransfers.Data.CurrentPage,
                cellarTransfers.Data.HasNext,
                cellarTransfers.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            
            return Ok(cellarTransfers.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CellarTransferCreateDTO obj)
        {
            var insert = await _cellarTransferApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CellarTransferUpdateDTO obj)
        {
            var cellarTransfer = await _cellarTransferApplication.GetByIdAsync(id);

            if (cellarTransfer.Data == null)
            {
                return NotFound(new ResponseError($"The cellar transfer id was not found."));
            }

            var update = await _cellarTransferApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var cellarTransfer = await _cellarTransferApplication.GetByIdAsync(id);

            if (cellarTransfer.Data == null)
            {
                return NotFound(new ResponseError($"The cellar transfer id was not found."));
            }

            var delete = await _cellarTransferApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }
    }
}
