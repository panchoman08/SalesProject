using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class BuyOrderApplication : IBuyOrderApplication
    {
        private readonly IBuyOrderDomain _buyOrderDomain;
        private readonly IMapper _mapper;

        public BuyOrderApplication(IBuyOrderDomain buyOrderDomain, IMapper mapper)
        {
            _buyOrderDomain = buyOrderDomain;
            _mapper = mapper;
        }


        #region async methods
        public async Task<Response<bool>> InsertAsync(BuyOrderCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buyOrder = _mapper.Map<BuyOrder>(obj);
                response.Data = await _buyOrderDomain.InsertAsync(buyOrder);
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
        public async Task<Response<bool>> UpdateAsync(int id, BuyOrderUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var buyOrder = _mapper.Map<BuyOrder>(obj);
                response.Data = await _buyOrderDomain.UpdateAsync(id, buyOrder);
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
                response.Data = await _buyOrderDomain.DeleteAsync(id);
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
        public async Task<Response<BuyOrderDTO>> GetByIdAsync(int id)
        {
            var response = new Response<BuyOrderDTO>();
            try
            {
                var buyOrder = await _buyOrderDomain.GetByIdAsync(id);

                response.Data = _mapper.Map<BuyOrderDTO>(buyOrder);
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<BuyOrderDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BuyOrderDTO>>();
            try
            {
                var buyOrder = await _buyOrderDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<BuyOrderDTO>>(buyOrder);
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<BuyOrderDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<BuyOrderDTO>>();
            try
            {
                var buyOrders = await _buyOrderDomain.GetAllWithPagingAsync();
                IEnumerable<BuyOrderDTO> buyOrdersIE = _mapper.Map<IEnumerable<BuyOrderDTO>>(await buyOrders.ToListAsync());

                response.Data = PagedList<BuyOrderDTO>.ToPagedList(buyOrdersIE, paginationParametersDTO.PageNumber,  paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<bool>> GenerateBuyBasedOnBuyOrder(int id)
        {
            var response = new Response<bool>();
            try
            {
                var buyOrder = await _buyOrderDomain.GetByIdAsync(id);

                var buy = _mapper.Map<Buy>(buyOrder);
                //buy.BuyDets = _mapper.Map<ICollection<BuyDet>>(buyOrder.BuyOrderDets);

                buy.BuyOrderId = id;
                buy.DocumentId = buyOrder.OutputDocumentId;

                response.Data = await _buyOrderDomain.GenerateBuyBasedOnBuyOrder(buy);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "The buy was generated successfully.";
                }
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
