using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SalesProject.Application.DTO.customer.category;
using SalesProject.Application.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/customerCat")]
    public class CustomerCatController : ControllerBase
    {
        private readonly ICustomerCatApplication _customerCatApplication;
        public CustomerCatController(ICustomerCatApplication customerCatApplication)
        {
            _customerCatApplication = customerCatApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerCatDTO>> GetById([FromRoute] int id)
        {
            var customerCat = await _customerCatApplication.GetByIdAsync(id);

            if (!customerCat.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customerCat.Message}"));
            }

            if (customerCat.Data == null)
            {
                return NotFound(new ResponseError($"The customer category id was not found."));
            }

            return Ok(customerCat.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CustomerCatDTO>> GetByName([FromRoute] string name)
        {
            var customer = await _customerCatApplication.GetByNameAsync(name);

            if (!customer.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customer.Message}"));
            }

            if (customer.Data == null)
            {
                return NotFound(new ResponseError($"{customer.Data}"));
            }

            return Ok(customer.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CustomerCatDTO>>> GetAll()
        {
            var customerCats = await _customerCatApplication.GetAllAsync();

            if (!customerCats.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customerCats.Data}"));
            }

            return Ok(customerCats.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<CustomerCatDTO>>> GetAllThatContainsName([FromRoute]string name)
        {
            var customerCats = await _customerCatApplication.GetAllTthatContainsNameAsync(name);

            if (!customerCats.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customerCats.Message}"));
            }

            return Ok(customerCats.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]CustomerCatCreateDTO customerCat)
        {
            var categories = await _customerCatApplication.GetAllAsync();
            var existCategory = categories.Data.FirstOrDefault(x => x.Name == customerCat.Name);

            if (existCategory != null)
            {
                return BadRequest(new ResponseError($"The category name -> {customerCat.Name} is already register"));
            }

            var insert = await _customerCatApplication.InsertAsync(customerCat);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody]CustomerCatUpdateDTO customer)
        {
            var category = await _customerCatApplication.GetByIdAsync(id);

            if (category.Data == null)
            {
                return NotFound(new ResponseError($"The customer category id was not found."));
            }

            var update = await _customerCatApplication.UpdateAsync(id, customer);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError($"{update.Message}"));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id) 
        {
            var category = await _customerCatApplication.GetByIdAsync(id);

            if (category.Data == null)
            {
                return NotFound(new ResponseError($"The customer category id was not found."));
            }

            var delete = await _customerCatApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }

    }
}
