using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.sale_price_category;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/salePriceCategory")]
    public class SalePriceCategoryController : ControllerBase
    {
        private readonly ISalePriceCategoryApplication _salePriceCategoryApplication;
        public SalePriceCategoryController(ISalePriceCategoryApplication salePriceCategoryApplication)
        {
            _salePriceCategoryApplication= salePriceCategoryApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SalePriceCatDTO>> GetById([FromRoute]int id)
        {
            var salePriceCat = await _salePriceCategoryApplication.GetByIdAsync(id);

            if (!salePriceCat.IsSuccess)
            {
                return BadRequest(new ResponseError(salePriceCat.Message));
            }

            if (salePriceCat.Data == null)
            {
                return NotFound(new ResponseError("The sale price category id was not found."));
            }

            return Ok(salePriceCat.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<SalePriceCatDTO>> GetByName([FromRoute] string name)
        {
            var salePriceCat = await _salePriceCategoryApplication.GetByNameAsync(name);

            if (!salePriceCat.IsSuccess)
            {
                return BadRequest(new ResponseError(salePriceCat.Message));
            }

            if (salePriceCat.Data == null)
            {
                return NotFound(new ResponseError("The sale price category name was not found."));
            }

            return Ok(salePriceCat.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<SalePriceCatDTO>> GetAllThatContainsName([FromRoute] string name)
        {
            var salePriceCat = await _salePriceCategoryApplication.GetAllThatContainsName(name);

            if (!salePriceCat.IsSuccess)
            {
                return BadRequest(new ResponseError(salePriceCat.Message));
            }

            return Ok(salePriceCat.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<SalePriceCatDTO>> GetAll()
        {
            var salePriceCat = await _salePriceCategoryApplication.GetAllAsync();

            if (!salePriceCat.IsSuccess)
            {
                return BadRequest(new ResponseError(salePriceCat.Message));
            }

            return Ok(salePriceCat.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SalePriceCatCreateDTO obj)
        {
            var insert = await _salePriceCategoryApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] SalePriceCatUpdateDTO obj)
        {
            var salePriceCat = await _salePriceCategoryApplication.GetByIdAsync(id);

            if (salePriceCat.Data == null)
            {
                return NotFound(new ResponseError("The sale price category id was not found."));
            }

            var update = await _salePriceCategoryApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var salePriceCat = await _salePriceCategoryApplication.GetByIdAsync(id);

            if (salePriceCat.Data == null)
            {
                return NotFound(new ResponseError("The sale price category id was not found."));
            }

            var delete = await _salePriceCategoryApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
