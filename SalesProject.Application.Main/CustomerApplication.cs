using SalesProject.Application.Interface;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;
using AutoMapper;
using SalesProject.Domain.Entity.Models;
using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Domain.Entity.Models.pagination;
using Microsoft.EntityFrameworkCore;

namespace SalesProject.Application.Main
{
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomerDomain customerDomain, IMapper mapper)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(CustomerCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(obj);
                response.Data = await _customerDomain.InsertAsync(customer);
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

        public async Task<Response<bool>> UpdateAsync(int id, CustomerUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(obj);
                response.Data = await _customerDomain.UpdateAsync(id, customer);
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
                response.Data = await _customerDomain.DeleteAsync(id);
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

        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<PagedList<CustomerDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParameters)
        {
            var response = new Response<PagedList<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllWithPagingAsync();
                IEnumerable<CustomerDTO> customersIE = _mapper.Map<IEnumerable<CustomerDTO>>(await customers.ToListAsync());

                response.Data = PagedList<CustomerDTO>.ToPagedList(customersIE, paginationParameters.PageNumber, paginationParameters.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _customerDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomerDTO>> GetByIdAsync(int id)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _customerDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<CustomerDTO>(customer);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomerDTO>> GetByNameAsync(string name)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _customerDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<CustomerDTO>(customer);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        
    }
}