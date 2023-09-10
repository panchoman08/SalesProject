using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDTO>> GetById([FromRoute] int id)
        {
            var customer = await _customerApplication.GetByIdAsync(id);

            if (!customer.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customer.Message}"));
            }

            if (customer.Data == null)
            {
                return NotFound(new ResponseError($"The customer id was not found"));
            }

            return Ok(customer.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CustomerDTO>> GetByName([FromRoute]string name)
        {
            var customer = await _customerApplication.GetByNameAsync(name);

            if (!customer.IsSuccess)
            {
                return BadRequest($"{customer.Message}");
            }

            if (customer.Data == null)
            {
                return NotFound(new ResponseError($"The customer name was not found"));
            }

            return Ok(customer.Data);
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAll()
        {
            var customers = await _customerApplication.GetAllAsync();

            if (!customers.IsSuccess)
            {
                return BadRequest(customers.Message);
            }

            return Ok(customers.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<CustomerDTO>>> GetAllWithPagination([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var customers = await _customerApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!customers.IsSuccess)
            {
                return BadRequest(new ResponseError(customers.Message));
            }

            var metadata = new
            {
                customers.Data.TotalCount,
                customers.Data.PageSize,
                customers.Data.CurrentPage,
                customers.Data.HasNext,
                customers.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(customers.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<CustomerDTO>>> GetAllThatContainsName([FromRoute]string name)
        {
            var customers = await _customerApplication.GetAllTthatContainsNameAsync(name);

            if (!customers.IsSuccess)
            {
                return BadRequest(new ResponseError($"{customers.Message}"));
            }

            return Ok(customers.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CustomerCreateDTO customer)
        {
            var insert = await _customerApplication.InsertAsync(customer);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError($"{insert.Message}"));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] CustomerUpdateDTO customer) 
        {
            var customerById = await _customerApplication.GetByIdAsync(id);

            if (customerById.Data == null)
            {
                return NotFound(new ResponseError($"The customer id was not found."));
            }

            var update = await _customerApplication.UpdateAsync(id, customer);

            if (!update.IsSuccess)
            {
                return BadRequest($"{update.Message}");
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var customer = await _customerApplication.GetByIdAsync(id);

            if (customer.Data == null)
            {
                return BadRequest(new ResponseError($"The customer id was not found."));
            }

            var delete = await _customerApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest($"{delete.Message}");
            }

            return Ok();
        }

    }
}
