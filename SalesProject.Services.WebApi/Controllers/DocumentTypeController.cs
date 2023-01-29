using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;
using System.Collections.Generic;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/DocumentType")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeApplication _documentTypeApplication;

        public DocumentTypeController(IDocumentTypeApplication documentTypeApplication) 
        {
            _documentTypeApplication = documentTypeApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DocumentTypeDTO>> GetById([FromRoute] int id)
        {
            var documentType = await _documentTypeApplication.GetByIdAsync(id);

            if (!documentType.IsSuccess)
            {
                return BadRequest(new ResponseError(documentType.Message));
            }

            if (documentType.Data == null)
            {
                return NotFound(new ResponseError("The document type id was not found."));
            }

            return Ok(documentType.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<DocumentTypeDTO>> GetByName([FromRoute]string name)
        {
            var documentType = await _documentTypeApplication.GetByNameAsync(name);

            if (!documentType.IsSuccess)
            {
                return BadRequest(new ResponseError(documentType.Message));
            }

            if (documentType.Data == null)
            {
                return NotFound(new ResponseError("The document type name was not found."));
            }

            return Ok(documentType.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<DocumentTypeDTO>> GetAllThatContainsName([FromRoute] string name)
        {
            var documentsType = await _documentTypeApplication.GetAllTthatContainsNameAsync(name);

            if (!documentsType.IsSuccess)
            {
                return BadRequest(new ResponseError(documentsType.Message));
            }

            return Ok(documentsType.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<DocumentTypeDTO>> GetAll()
        {
            var documentsType = await _documentTypeApplication.GetAllAsync();

            if (!documentsType.IsSuccess)
            {
                return BadRequest(new ResponseError(documentsType.Message));
            }

            return Ok(documentsType.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]DocumentTypeCreateDTO obj)
        {
            var insert = await _documentTypeApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id,[FromBody] DocumentTypeUpdateDTO obj)
        {
            var documentType = await _documentTypeApplication.GetByIdAsync(id);

            if (documentType.Data == null)
            {
                return NotFound(new ResponseError("The document type id was not found."));
            }

            var update = await _documentTypeApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var documentType = await _documentTypeApplication.GetByIdAsync(id);

            if (documentType.Data == null)
            {
                return NotFound(new ResponseError("The document type id was not found."));
            }

            var delete = await _documentTypeApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
