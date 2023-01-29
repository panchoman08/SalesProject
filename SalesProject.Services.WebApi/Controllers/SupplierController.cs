using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/supplier")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierApplication _supplierApplication;
        public SupplierController(ISupplierApplication supplierApplication) 
        {
            _supplierApplication = supplierApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDTO>> GetById([FromRoute]int id)
        {
            var supplier = await _supplierApplication.GetByIdAsync(id);

            if (!supplier.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplier.Message}"));
            }

            if (supplier.Data == null)
            {
                return NotFound(new ResponseError($"The supplier id was not found."));
            }

            return Ok(supplier.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SupplierDTO>> GetByName([FromRoute]string name)
        {
            var supplier = await _supplierApplication.GetByNameAsync(name);

            if (!supplier.IsSuccess)
            {
                return BadRequest(new ResponseError($"{supplier.Message}"));
            }

            if (supplier.Data == null)
            {
                return NotFound(new ResponseError($"The supplier id was not found."));
            }

            return Ok(supplier.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<SupplierDTO>>> GetAll()
        {
            var suppliers = await _supplierApplication.GetAllAsync();

            if (!suppliers.IsSuccess)
            {
                return BadRequest(new ResponseError($"{suppliers.Message}"));
            }

            return Ok(suppliers.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<SupplierDTO>>> GetAll([FromRoute]string name)
        {
            var suppliers = await _supplierApplication.GetAllTthatContainsNameAsync(name);

            if (!suppliers.IsSuccess)
            {
                return BadRequest(new ResponseError($"{suppliers.Message}"));
            }

            return Ok(suppliers.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]SupplierCreateDTO supplier)
        {
            var insert = await _supplierApplication.InsertAsync(supplier);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]SupplierUpdateDTO obj)
        {
            var supplier = await _supplierApplication.GetByIdAsync(id);

            if (supplier.Data == null)
            {
                return NotFound(new ResponseError("The supplier id was not found."));
            }

            var update = await _supplierApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id)
        {
            var supplier = await _supplierApplication.GetByIdAsync(id);

            if (supplier.Data == null)
            {
                return NotFound(new ResponseError("The supplier id was not found."));
            }
            var update = await _supplierApplication.DeleteAsync(id);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }
    }
}
