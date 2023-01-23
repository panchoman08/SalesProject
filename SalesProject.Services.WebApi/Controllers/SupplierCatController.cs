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
    }
}
