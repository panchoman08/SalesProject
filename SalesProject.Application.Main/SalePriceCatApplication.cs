using AutoMapper;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.DTO.sale_price_category;
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
    public class SalePriceCatApplication : ISalePriceCategoryApplication
    {
        private readonly ISalePriceCategoryDomain _salePriceCategoryDomain;
        private readonly IMapper _mapper;

        public SalePriceCatApplication(ISalePriceCategoryDomain salePriceCategoryDomain, IMapper mapper)
        {
            _salePriceCategoryDomain = salePriceCategoryDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(SalePriceCatCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var salePriceCat = _mapper.Map<CategorySalePrice>(obj);
                response.Data = await _salePriceCategoryDomain.InsertAsync(salePriceCat);
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
        public async Task<Response<bool>> UpdateAsync(int id, SalePriceCatUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var salePriceCat = _mapper.Map<CategorySalePrice>(obj);
                response.Data = await _salePriceCategoryDomain.UpdateAsync(id, salePriceCat);
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
                response.Data = await _salePriceCategoryDomain.DeleteAsync(id);
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
        public async Task<Response<SalePriceCatDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SalePriceCatDTO>();
            try
            {
                var salePriceCat = await _salePriceCategoryDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SalePriceCatDTO>(salePriceCat);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<SalePriceCatDTO>> GetByNameAsync(string name)
        {
            var response = new Response<SalePriceCatDTO>();
            try
            {
                var salePriceCat = await _salePriceCategoryDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<SalePriceCatDTO>(salePriceCat);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
        public async Task<Response<IEnumerable<SalePriceCatDTO>>> GetAllThatContainsName(string name)
        {
            var response = new Response<IEnumerable<SalePriceCatDTO>>();
            try
            {
                var salePriceCat = await _salePriceCategoryDomain.GetAllThatContainsName(name);
                response.Data = _mapper.Map<IEnumerable<SalePriceCatDTO>>(salePriceCat);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<Response<IEnumerable<SalePriceCatDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SalePriceCatDTO>>();
            try
            {
                var salePriceCat = await _salePriceCategoryDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SalePriceCatDTO>>(salePriceCat);
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
