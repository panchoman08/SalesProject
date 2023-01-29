using AutoMapper;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class ProductBrandApplication : IProductBrandApplication
    {
        private readonly IProductBrandDomain _productBrandDomain;
        private readonly IMapper _mapper;

        public ProductBrandApplication(IProductBrandDomain productBrandDomain, IMapper mapper)
        {
            _productBrandDomain = productBrandDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(ProductBrandCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var brand = _mapper.Map<Brand>(obj);
                response.Data = await _productBrandDomain.InsertAsync(brand);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(int id, ProductBrandUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var brand = _mapper.Map<Brand>(obj);
                response.Data = await _productBrandDomain.UpdateAsync(id, brand);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productBrandDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ProductBrandDTO>> GetByIdAsync(int id)
        {
            var response = new Response<ProductBrandDTO>();
            try
            {
                var brand = await _productBrandDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<ProductBrandDTO>(brand);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ProductBrandDTO>> GetByNameAsync(string name)
        {
            var response = new Response<ProductBrandDTO>();
            try
            {
                var product = await _productBrandDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<ProductBrandDTO>(product);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<ProductBrandDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<ProductBrandDTO>>();
            try
            {
                var brands = await _productBrandDomain.GetAllThatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<ProductBrandDTO>>(brands);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<ProductBrandDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductBrandDTO>>();
            try
            {
                var brands = await _productBrandDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ProductBrandDTO>>(brands);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        #endregion

    }
}
