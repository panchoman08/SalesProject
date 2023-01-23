using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.Interface;
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

        [HttpGet("thatContainsName/{name}")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllThatContainsName([FromRoute] string name)
        {
            var product = await _productApplication.GetAllTthatContainsNameAsync(name);

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            return Ok(product.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllThatContainsName()
        {
            var product = await _productApplication.GetAllAsync();

            if (!product.IsSuccess)
            {
                return BadRequest(new ResponseError(product.Message));
            }

            return Ok(product.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProductCreateDTO product)
        {
            var productBySku = await _productApplication.GetBySkuAsync(product.Sku);

            if (productBySku.Data != null)
            {
                return BadRequest(new ResponseError($"There is already a product created with de sku: {product.Sku}"));
            }

            var insert = await _productApplication.InsertAsync(product);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id, [FromBody] ProductUpdateDTO product)
        {
            var insert = await _productApplication.UpdateAsync(id, product);

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
                return NotFound("The product id was not found.");
            }

            var delete = await _productApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError($"T"));
            }

            return Ok();
        }
    }
}
