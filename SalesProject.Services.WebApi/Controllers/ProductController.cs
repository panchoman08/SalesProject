using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.Interface;
using SalesProject.Application.Main;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute]int id)
        {
            var product = await _productApplication.GetByIdAsync(id);

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            if (product.Data == null) 
            {
                return NotFound(new ResponseError("The product id was not found."));
            }

            return Ok(product.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductDTO>> GetByName([FromRoute] string name)
        {
            var product = await _productApplication.GetByNameAsync(name);

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            if (product.Data == null)
            {
                return NotFound(new ResponseError("The product name was not found."));
            }

            return Ok(product.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            var product = await _productApplication.GetAllTthatContainsNameAsync(name);

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            return Ok(product.Data);
        }

        [HttpGet("allThatContainsSku/{sku}")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllThatContainsSku([FromRoute]string sku)
        {
            var products = await _productApplication.GetAllThatContainsSkuAsync(sku);

            if (!products.IsSuccess)
            {
                return BadRequest(new ResponseError(products.Message));
            }

            return Ok(products.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var product = await _productApplication.GetAllAsync();

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            return Ok(product.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var products = await _productApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!products.IsSuccess)
            {
                return BadRequest(new ResponseError(products.Message));
            }

            var metadata = new
            {
                products.Data.TotalCount,
                products.Data.PageSize,
                products.Data.CurrentPage,
                products.Data.HasNext,
                products.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(products.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProductCreateDTO product)
        {
            var insert = await _productApplication.InsertAsync(product);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] ProductUpdateDTO obj)
        {
            var product = await _productApplication.GetByIdAsync(id);

            if (product.Data == null)
            {
                return NotFound(new ResponseError("The product id was not found."));
            }

            var insert = await _productApplication.UpdateAsync(id, obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var product = await _productApplication.GetByIdAsync(id);

            if (product.Data == null)
            {
                return NotFound(new ResponseError("The product id was not found."));
            }

            var delete = await _productApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"{delete.Message}"));
            }

            return Ok();
        }
    }
}
