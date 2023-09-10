using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.Interface;
using SalesProject.Application.Main;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/productBrand")]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandApplication _productBrandApplication;

        public ProductBrandController(IProductBrandApplication productBrandApplication)
        {
            _productBrandApplication = productBrandApplication;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductBrandDTO>> GetById([FromRoute]int id)
        {
            var brand = await _productBrandApplication.GetByIdAsync(id);

            if (!brand.IsSuccess)
            {
                return BadRequest(new ResponseError($"{brand.Message}"));
            }

            if (brand.Data == null)
            {
                return NotFound(new ResponseError("The product brand id was not found."));
            }

            return Ok(brand.Data);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductBrandDTO>> GetByName([FromRoute] string name)
        {
            var brand = await _productBrandApplication.GetByNameAsync(name);

            if (!brand.IsSuccess)
            {
                return BadRequest(new ResponseError($"{brand.Message}"));
            }

            if (brand.Data == null)
            {
                return NotFound(new ResponseError("The product brand name was not found."));
            }

            return Ok(brand.Data);
        }

        [HttpGet("allThatContainsName/{name}")]
        public async Task<ActionResult<List<ProductBrandDTO>>> GetAllThatContainsName([FromRoute]string name)
        {
            var brands = await _productBrandApplication.GetAllTthatContainsNameAsync(name);

            if (!brands.IsSuccess)
            {
                return BadRequest(new ResponseError(brands.Message));
            }

            return Ok(brands.Data);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductBrandDTO>>> GetAll()
        {
            var brands = await _productBrandApplication.GetAllAsync();

            if (!brands.IsSuccess)
            {
                return BadRequest(new ResponseError(brands.Message));
            }

            return Ok(brands.Data);
        }

        [HttpGet("allWithPaging")]
        public async Task<ActionResult<PagedList<ProductBrandDTO>>> GetAllWithPaging([FromQuery] PaginationParametersDTO paginationParametersDTO)
        {
            var productBrands = await _productBrandApplication.GetAllWithPagingAsync(paginationParametersDTO);

            if (!productBrands.IsSuccess)
            {
                return BadRequest(new ResponseError(productBrands.Message));
            }

            var metadata = new
            {
                productBrands.Data.TotalCount,
                productBrands.Data.PageSize,
                productBrands.Data.CurrentPage,
                productBrands.Data.HasNext,
                productBrands.Data.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(productBrands.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ProductBrandCreateDTO obj)
        {
            var insert = await _productBrandApplication.InsertAsync(obj);

            if (!insert.IsSuccess)
            {
                return BadRequest(new ResponseError(insert.Message));
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id,[FromBody] ProductBrandUpdateDTO obj)
        {
            var productBrand = await _productBrandApplication.GetByIdAsync(id);

            if (productBrand.Data == null)
            {
                return NotFound(new ResponseError("The product brand id was not found."));
            }

            var update = await _productBrandApplication.UpdateAsync(id, obj);

            if (!update.IsSuccess)
            {
                return BadRequest(new ResponseError(update.Message));
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var productBrand = await _productBrandApplication.GetByIdAsync(id);

            if (productBrand.Data == null)
            {
                return NotFound(new ResponseError("The product brand id was not found."));
            }

            var delete = await _productBrandApplication.DeleteAsync(id);

            if (!delete.IsSuccess)
            {
                return BadRequest(new ResponseError(delete.Message));
            }

            return Ok();
        }
    }
}
