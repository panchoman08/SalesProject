using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.supplier.category;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/supplierCat")]
    public class SupplierCatController : ControllerBase
    {
        private readonly ISupplierCatApplication _supplierCatApplication;
        public SupplierCatController(ISupplierCatApplication supplierCatApplication) 
        {
            _supplierCatApplication = supplierCatApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierCatDTO>> GetById([FromRoute]int id)
        {
            var supplierCat = await _supplierCatApplication.GetByIdAsync(id);

            if (!supplierCat.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplierCat.Message}"));
            }

            if (supplierCat.Data == null)
            {
                return NotFound(new ResponseError($"The supplier category id was not found."));
            }

            return Ok(supplierCat.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SupplierCatDTO>> GetByName([FromRoute] string name)
        {
            var supplierCat = await _supplierCatApplication.GetByNameAsync(name);

            if (!supplierCat.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplierCat.Message}"));
            }

            if (supplierCat.Data == null)
            {
                return NotFound(new ResponseError($"The supplier category id was not found."));
            }

            return Ok(supplierCat.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<SupplierCatDTO>> GetAllThatContainsName([FromRoute] string name)
        {
            var supplierCats = await _supplierCatApplication.GetAllTthatContainsNameAsync(name);

            if (!supplierCats.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplierCats.Message}"));
            }

            return Ok(supplierCats.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<SupplierCatDTO>> GetAll()
        {
            var supplierCats = await _supplierCatApplication.GetAllAsync();

            if (!supplierCats.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplierCats.Message}"));
            }

            return Ok(supplierCats.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SupplierCatCreateDTO obj)
        {
            var insert = await _supplierCatApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] SupplierCatUpdateDTO obj)
        {
            var supplierCat = await _supplierCatApplication.GetByIdAsync(id);

            if (supplierCat == null)
            {
                return NotFound(new ResponseError("The supplier category id was not found."));
            }

            var update = await _supplierCatApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var supplierCat = await _supplierCatApplication.GetByIdAsync(id);

            if (supplierCat == null)
            {
                return NotFound(new ResponseError("The supplier category id was not found."));
            }

            var delete = await _supplierCatApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
