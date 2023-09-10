using AutoMapper;
using Microsoft.Identity.Client;
using SalesProject.Application.DTO.buy_return.buy_return;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class BuyReturnApplication : IBuyReturnApplication
    {
        private readonly IBuyReturnDomain _buyReturnDomain;
        private readonly IMapper _mapper;

        public BuyReturnApplication(IBuyReturnDomain buyReturnDomain, IMapper mapper)
        {
            _buyReturnDomain = buyReturnDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(BuyReturnCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buyReturn = _mapper.Map<BuyReturn>(obj);
                response.Data = await _buyReturnDomain.InsertAsync(buyReturn);

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
        public async Task<Response<bool>> UpdateAsync(int id, BuyReturnUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buyReturn = _mapper.Map<BuyReturn>(obj);
                response.Data = await _buyReturnDomain.UpdateAsync(id, buyReturn);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated succesfully.";
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
                response.Data = await _buyReturnDomain.DeleteAsync(id);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.s";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<BuyReturnDTO>> GetByIdAsync(int id)
        {
            var response = new Response<BuyReturnDTO>();
            try
            {
                var buyReturn = await _buyReturnDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<BuyReturnDTO>(buyReturn);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<BuyReturnDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BuyReturnDTO>>();
            try
            {
                var buyReturns = await _buyReturnDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<BuyReturnDTO>>(buyReturns);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<BuyReturnDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<BuyReturnDTO>>();
            try
            {
                var buyReturns = await _buyReturnDomain.GetAllWithPagingAsync();
                IEnumerable<BuyReturnDTO> buyReturnsIE = _mapper.Map<IEnumerable<BuyReturnDTO>>(buyReturns);

                response.Data = PagedList<BuyReturnDTO>.ToPagedList(buyReturnsIE, paginationParametersDTO.PageNumber,  paginationParametersDTO.PageSize);
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
