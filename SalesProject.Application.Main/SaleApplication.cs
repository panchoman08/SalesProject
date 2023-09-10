using AutoMapper;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale.sale;
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
    public class SaleApplication : ISaleApplication
    {
        private readonly ISaleDomain _saleDomain;
        private readonly IMapper _mapper;

        public SaleApplication(ISaleDomain saleDomain, IMapper mapper)
        {
            _saleDomain= saleDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(SaleCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var sale = _mapper.Map<Sale>(obj);
                response.Data = await _saleDomain.InsertAsync(sale);
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
        public async Task<Response<bool>> UpdateAsync(int id, SaleUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var sale = _mapper.Map<Sale>(obj);
                response.Data = await _saleDomain.UpdateAsync(id, sale);
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
                response.Data = await _saleDomain.DeleteAsync(id);

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
        public async Task<Response<SaleDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SaleDTO>();
            try
            {
                var sale = await _saleDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SaleDTO>(sale);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<SaleDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SaleDTO>>();
            try
            {
                var sales = await _saleDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SaleDTO>>(sales);
                response.IsSuccess = true;
                response.Message = "Query Successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<SaleDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<SaleDTO>>();
            try
            {
                var sales = await _saleDomain.GetAllWithPagingAsync();
                IEnumerable<SaleDTO> salesIE = _mapper.Map<IEnumerable<SaleDTO>>(sales);

                response.Data = PagedList<SaleDTO>.ToPagedList(salesIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message}\n {ex.InnerException}";
            }

            return response;
        }
        #endregion
    }
}
