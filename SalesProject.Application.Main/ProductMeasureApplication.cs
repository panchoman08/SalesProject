using AutoMapper;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class ProductMeasureApplication : IProductMeasureApplication
    {
        private readonly IProductMeasureDomain _productMeasureDomain;
        private readonly IMapper _mapper;

        public ProductMeasureApplication(IProductMeasureDomain productMeasureDomain,
                IMapper mapper)
        {
            _productMeasureDomain = productMeasureDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(ProductMeasureCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var measure = _mapper.Map<Measure>(obj);
                response.Data = await _productMeasureDomain.InsertAsync(measure);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(int id, ProductMeasureUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var measure = _mapper.Map<Measure>(obj);
                response.Data = await _productMeasureDomain.UpdateAsync(id, measure);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _productMeasureDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<IEnumerable<ProductMeasureDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductMeasureDTO>>();
            try
            {
                var measures = await _productMeasureDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ProductMeasureDTO>>(measures);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<PagedList<ProductMeasureDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<ProductMeasureDTO>>();
            try
            {
                var measures = await _productMeasureDomain.GetAllWithPagingAsync();
                IEnumerable<ProductMeasureDTO> measuresIE = _mapper.Map<IEnumerable<ProductMeasureDTO>>(measures);

                response.Data = PagedList<ProductMeasureDTO>.ToPagedList(measuresIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<IEnumerable<ProductMeasureDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<ProductMeasureDTO>>();
            try
            {
                var measures = await _productMeasureDomain.GetAllThatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<ProductMeasureDTO>>(measures);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<ProductMeasureDTO>> GetByIdAsync(int id)
        {
            var response = new Response<ProductMeasureDTO>();
            try
            {
                var measure = await _productMeasureDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<ProductMeasureDTO>(measure);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        
    }
}
