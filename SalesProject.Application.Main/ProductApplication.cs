using AutoMapper;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductDomain _productDomain;
        private readonly IMapper _mapper;
        public ProductApplication(IProductDomain productDomain, IMapper mapper) 
        {
            _productDomain = productDomain;
            _mapper = mapper;
        }
        #region async methods
        public async Task<Response<bool>> InsertAsync(ProductCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Product>(obj);
                response.Data = await _productDomain.InsertAsync(product);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro agregado correctamente.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(int id, ProductUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Product>(obj);
                response.Data = await _productDomain.UpdateAsync(id, product);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado correctamente.";
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
                response.Data = await _productDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro eliminado correctamente.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ProductDTO>> GetByIdAsync(int id)
        {
            var response = new Response<ProductDTO>();
            try
            {
                var product = await _productDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<ProductDTO>(product);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ProductDTO>> GetByNameAsync(string name)
        {
            var response = new Response<ProductDTO>();
            try
            {
                var product = await _productDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<ProductDTO>(product);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ProductDTO>> GetBySkuAsync(string sku)
        {
            var response = new Response<ProductDTO>();
            try
            {
                var product = await _productDomain.GetBySkuAsync(sku);
                response.Data = _mapper.Map<ProductDTO>(product);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<ProductDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<ProductDTO>>();
            try
            {
                var product = await _productDomain.GetAllThatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<ProductDTO>>(product);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductDTO>>();
            try
            {
                var product = await _productDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ProductDTO>>(product);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa.";
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
