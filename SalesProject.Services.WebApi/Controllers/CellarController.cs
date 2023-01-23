using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/cellar")]
    public class CellarController : ControllerBase
    {
        private readonly ICellarApplication _cellarApplication;

        public CellarController(ICellarApplication cellarApplication)
        {
            _cellarApplication = cellarApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarDTO>> GetById([FromRoute]int id)
        {
            var cellar = await _cellarApplication.GetByIdAsync(id);

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar id was not found"));
            }

            return Ok(cellar.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CellarDTO>> GetByName([FromRoute]string name)
        {
            var cellar = await _cellarApplication.GetByNameAsync(name);

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            if (cellar.Data == null)
            {
                return NotFound(new ResponseError("The cellar name was not found"));
            }

            return Ok(cellar.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CellarDTO>>> GetAll()
        {
            var cellar = await _cellarApplication.GetAllAsync();

            if (!cellar.IsSuccess)
            {
                return BadRequest(new ResponseError(cellar.Message));
            }

            return Ok(cellar.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]CellarCreateDTO obj)
        {
            var insert = await _cellarApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] CellarUpdateDTO obj)
        {
            var update = await _cellarApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var delete = await _cellarApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }
    }
}
