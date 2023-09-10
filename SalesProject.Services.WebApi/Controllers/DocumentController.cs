using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;
using System.Formats.Asn1;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentApplication _documentApplication;

        public DocumentController(IDocumentApplication documentApplication)
        {
            _documentApplication = documentApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentDTO>> GetById([FromRoute] int id)
        {
            var document = await _documentApplication.GetByIdAsync(id);

            if (!document.IsSuccess)
            {
                return BadRequest(new ResponseError(document.Message));
            }

            if (document.Data == null)
            {
                return NotFound(new ResponseError("The document id was not found."));
            }

            return Ok(document.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<DocumentDTO>> GetByName([FromRoute] string name)
        {
            var document = await _documentApplication.GetByNameAsync(name);

            if (!document.IsSuccess)
            {
                return BadRequest(new ResponseError(document.Message));
            }

            if (document.Data == null)
            {
                return NotFound(new ResponseError("The document id was not found."));
            }

            return Ok(document.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            var documents = await _documentApplication.GetAllTthatContainsNameAsync(name);

            if (!documents.IsSuccess)
            {
                return BadRequest(new ResponseError(documents.Message));
            }

            return Ok(documents.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetAll()
        {
            var documents = await _documentApplication.GetAllAsync();

            if (!documents.IsSuccess)
            {
                return BadRequest(new ResponseError(documents.Message));
            }

            return Ok(documents.Data);
        }

        [HttpGet("allByDocumentType/{name}")]
        public async Task<ActionResult<List<DocumentDTO>>> GetByDocumentType([FromRoute] string name)
        {
            var documents = await _documentApplication.GetAllByDocumentTypeAsync(name);

            if (!documents.IsSuccess)
            {
                return BadRequest(new ResponseError(documents.Message));
            }

            return Ok(documents.Data);
        }
        

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<DocumentDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var documents = await _documentApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!documents.IsSuccess)
            {
                return BadRequest(new ResponseError(documents.Message));
            }

            var metadata = new
            {
                documents.Data.TotalCount,
                documents.Data.PageSize,
                documents.Data.CurrentPage,
                documents.Data.HasNext,
                documents.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(documents.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]DocumentCreateDTO obj)
        {
            var insert = await _documentApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] DocumentUpdateDTO obj)
        {
            var document = await _documentApplication.GetByIdAsync(id);

            if (document.Data == null)
            {
                return NotFound(new ResponseError("The document id was not found."));
            }

            var update = await _documentApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var document = await _documentApplication.GetByIdAsync(id);

            if (document.Data == null)
            {
                return NotFound(new ResponseError("The document id was not found."));
            }

            var delete = await _documentApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
