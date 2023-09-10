using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class BuyApplication : IBuyApplication
    {
        private readonly IBuyDomain _buyDomain;
        private readonly IMapper _mapper;

        public BuyApplication(IBuyDomain buyDomain, IMapper mapper)
        {
            _buyDomain = buyDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(BuyCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buy = _mapper.Map<Buy>(obj);
                response.Data = await _buyDomain.InsertAsync(buy);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(int id, BuyUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buy = _mapper.Map<Buy>(obj);
                response.Data = await _buyDomain.UpdateAsync(id, buy);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully";
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
                response.Data = await _buyDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<BuyDTO>> GetByIdAsync(int id)
        {
            var response = new Response<BuyDTO>();
            try
            {
                var buyOrder = await _buyDomain.GetByIdAsync(id);

                response.Data = _mapper.Map<BuyDTO>(buyOrder);
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<BuyDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BuyDTO>>();
            try
            {
                var buyOrder = await _buyDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<BuyDTO>>(buyOrder);
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<BuyDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<BuyDTO>>();
            try
            {
                var buys = await _buyDomain.GetAllWithPagingAsync();
                IEnumerable<BuyDTO> buysIE = _mapper.Map<IEnumerable<BuyDTO>>(await buys.ToListAsync());

                response.Data = PagedList<BuyDTO>.ToPagedList(buysIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
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
