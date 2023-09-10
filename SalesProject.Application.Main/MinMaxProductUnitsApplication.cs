using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.min_max;
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
    public class MinMaxProductUnitsApplication : IMinMaxProductUnitsApplication
    {
        private readonly IMinMaxProductUnitsDomain _minMaxProductUnitsDomain;
        private readonly IMapper _mapper;
        public MinMaxProductUnitsApplication(IMinMaxProductUnitsDomain minMaxProductUnitsDomain,
                IMapper mapper) 
        {
            _minMaxProductUnitsDomain = minMaxProductUnitsDomain;
            _mapper = mapper;
        }
        public async Task<Response<bool>> InsertAsync(MinMaxProductUnitsCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var minMaxProd = _mapper.Map<MinMaxProd>(obj);
                response.Data = await _minMaxProductUnitsDomain.InsertAsync(minMaxProd);
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

        public async Task<Response<bool>> UpdateAsync(int id, MinMaxProductUnitsUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var minMaxProd = _mapper.Map<MinMaxProd>(obj);
                response.Data = await _minMaxProductUnitsDomain.UpdateAsync(id, minMaxProd);
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
                response.Data = await _minMaxProductUnitsDomain.DeleteAsync(id);
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

        public async Task<Response<IEnumerable<MinMaxProductUnitsDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<MinMaxProductUnitsDTO>>();
            try
            {
                var minMaxProd = await _minMaxProductUnitsDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<MinMaxProductUnitsDTO>>(minMaxProd);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<PagedList<MinMaxProductUnitsDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<MinMaxProductUnitsDTO>>();
            try
            {
                var minMaxProd = await _minMaxProductUnitsDomain.GetAllWithPagingAsync();
                IEnumerable<MinMaxProductUnitsDTO> minMaxProdIE = _mapper.Map<IEnumerable<MinMaxProductUnitsDTO>>(await minMaxProd.ToListAsync());

                response.Data = PagedList<MinMaxProductUnitsDTO>.ToPagedList(minMaxProdIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<MinMaxProductUnitsDTO>> GetByIdAsync(int id)
        {
            var response = new Response<MinMaxProductUnitsDTO>();
            try
            {
                var minMaxProd = await _minMaxProductUnitsDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<MinMaxProductUnitsDTO>(minMaxProd);
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
