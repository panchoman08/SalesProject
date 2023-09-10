using AutoMapper;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.Main
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryDomain _productCategoryDomain;
        private readonly IMapper _mapper;
        public ProductCategoryApplication(IProductCategoryDomain productCategoryDomain,
                IMapper mapper) 
        {
            _productCategoryDomain = productCategoryDomain;
            _mapper = mapper;
        }
        public async Task<Response<bool>> InsertAsync(ProductCatCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var category = _mapper.Map<ProductCat>(obj);
                response.Data = await _productCategoryDomain.InsertAsync(category);
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

        public async Task<Response<bool>> UpdateAsync(int id, ProductCatUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var category = _mapper.Map<ProductCat>(obj);
                response.Data = await _productCategoryDomain.UpdateAsync(id, category);
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
                response.Data = await _productCategoryDomain.DeleteAsync(id);
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

        public async Task<Response<IEnumerable<ProductCatDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ProductCatDTO>>();
            try
            {
                var categories = await _productCategoryDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<ProductCatDTO>>(categories);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<PagedList<ProductCatDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<ProductCatDTO>>();
            try
            {
                var categories = await _productCategoryDomain.GetAllWithPagingAsync();
                IEnumerable<ProductCatDTO> categoriesIE = _mapper.Map<IEnumerable<ProductCatDTO>>(categories);

                response.Data = PagedList<ProductCatDTO>.ToPagedList(categoriesIE, paginationParametersDTO.PageNumber,
                                paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<IEnumerable<ProductCatDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<ProductCatDTO>>();
            try
            {
                var categories = await _productCategoryDomain.GetAllThatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<ProductCatDTO>>(categories);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<ProductCatDTO>> GetByIdAsync(int id)
        {
            var response = new Response<ProductCatDTO>();
            try
            {
                var category = await _productCategoryDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<ProductCatDTO>(category);
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
