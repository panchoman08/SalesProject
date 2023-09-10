using AutoMapper;
using AutoMapper.Configuration.Annotations;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_return.sale_return;
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
    public class SaleReturnApplication : ISaleReturnApplication
    {
        private readonly ISaleReturnDomain _saleReturnDomain;
        private readonly IMapper _mapper;

        public SaleReturnApplication(ISaleReturnDomain saleReturnDomain, IMapper mapper)
        {
            _saleReturnDomain = saleReturnDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(SaleReturnCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var saleReturn = _mapper.Map<SaleReturn>(obj);
                response.Data = await _saleReturnDomain.InsertAsync(saleReturn);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register inserted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }
        public async Task<Response<bool>> UpdateAsync(int id, SaleReturnUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var saleReturn = _mapper.Map<SaleReturn>(obj);
                response.Data = await _saleReturnDomain.UpdateAsync(id, saleReturn);
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
                response.Data = await _saleReturnDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted succesfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<SaleReturnDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SaleReturnDTO>();
            try
            {
                var saleReturn = await _saleReturnDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SaleReturnDTO>(saleReturn);
                response.IsSuccess = true;
                response.Message = $"Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<SaleReturnDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SaleReturnDTO>>();
            try
            {
                var saleReturn = await _saleReturnDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SaleReturnDTO>>(saleReturn);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<SaleReturnDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<SaleReturnDTO>>();
            try
            {
                var saleReturns = await _saleReturnDomain.GetAllWithPagingAsync();
                IEnumerable<SaleReturnDTO> saleReturnsIE = _mapper.Map<IEnumerable<SaleReturnDTO>>(saleReturns);

                response.Data = PagedList<SaleReturnDTO>.ToPagedList(saleReturnsIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }
        #endregion
    }
}
