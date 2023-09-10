using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_order.sale_order;
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
    public class SaleOrderApplication : ISaleOrderApplication
    {
        private readonly ISaleOrderDomain _saleOrderDomain;
        private readonly IMapper _mapper;

        public SaleOrderApplication(ISaleOrderDomain saleOrderDomain, IMapper mapper)
        {
            _saleOrderDomain = saleOrderDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(SaleOrderCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var saleOrder = _mapper.Map<SaleOrder>(obj);
                response.Data = await _saleOrderDomain.InsertAsync(saleOrder);
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
        public async Task<Response<bool>> UpdateAsync(int id, SaleOrderUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var saleOrder = _mapper.Map<SaleOrder>(obj);
                response.Data = await _saleOrderDomain.UpdateAsync(id, saleOrder);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated succesfully.";
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
                response.Data = await _saleOrderDomain.DeleteAsync(id);
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
        public async Task<Response<SaleOrderDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SaleOrderDTO>();
            try
            {
                var saleOrder = await _saleOrderDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SaleOrderDTO>(saleOrder);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }
        public async Task<Response<IEnumerable<SaleOrderDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SaleOrderDTO>>();
            try
            {
                var saleOrders = await _saleOrderDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SaleOrderDTO>>(saleOrders);
                response.IsSuccess = true;
                response.Message = "Query succesfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }
            return response;
        }

        public async Task<Response<PagedList<SaleOrderDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<SaleOrderDTO>>();
            try
            {
                var saleOrders = await _saleOrderDomain.GetAllWithPagingAsync();
                IEnumerable<SaleOrderDTO> saleOrdersIE = _mapper.Map<IEnumerable<SaleOrderDTO>>(saleOrders);

                response.Data = PagedList<SaleOrderDTO>.ToPagedList(saleOrdersIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<bool>> GenerateSaleBasedOnSaleOrder(int id)
        {
            var response = new Response<bool>();
            try
            {
                var saleOrder = await _saleOrderDomain.GetByIdAsync(id);

                var sale = _mapper.Map<Sale>(saleOrder);
                sale.SaleDets = _mapper.Map<ICollection<SaleDet>>(saleOrder.SaleOrderDets);

                sale.SaleOrderId = id;
                sale.DocumentId = saleOrder.DocumentId;

                response.Data = await _saleOrderDomain.GenerateSaleBasedOnSaleOrder(sale);

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
        #endregion

    }
}
