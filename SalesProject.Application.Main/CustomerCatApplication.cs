using AutoMapper;
using SalesProject.Application.DTO.customer;
using SalesProject.Application.DTO.customer.category;
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
    public class CustomerCatApplication : ICustomerCatApplication
    {

        private readonly ICustomerCatDomain _customerCatDomain;
        private readonly IMapper _mapper;

        public CustomerCatApplication(ICustomerCatDomain customerCatDomain, IMapper mapper)
        {
            _customerCatDomain = customerCatDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(CustomerCatCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<CustomerCat>(obj);
                response.Data = await _customerCatDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro agregado correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(int id, CustomerCatUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<CustomerCat>(obj);
                response.Data = await _customerCatDomain.UpdateAsync(id, customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado correctamente";
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
                response.Data = await _customerCatDomain.DeleteAsync(id);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerCatDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerCatDTO>>();
            try
            {
                var customers = await _customerCatDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerCatDTO>>(customers);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomerCatDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<CustomerCatDTO>>();
            try
            {
                var customers = await _customerCatDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<CustomerCatDTO>>(customers);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomerCatDTO>> GetByIdAsync(int id)
        {
            var response = new Response<CustomerCatDTO>();
            try
            {
                var customer = await _customerCatDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<CustomerCatDTO>(customer);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomerCatDTO>> GetByNameAsync(string name)
        {
            var response = new Response<CustomerCatDTO>();
            try
            {
                var customer = await _customerCatDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<CustomerCatDTO>(customer);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
