using AutoMapper;
using SalesProject.Application.DTO.customer;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class SupplierApplication : ISupplierApplication
    {
        private readonly ISupplierDomain _supplierDomain;
        private readonly IMapper _mapper;
        public SupplierApplication(ISupplierDomain supplierDomain, IMapper mapper) 
        {
            _supplierDomain = supplierDomain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> InsertAsync(SupplierCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var supplier = _mapper.Map<Supplier>(obj);
                response.Data = await _supplierDomain.InsertAsync(supplier);
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

        public async Task<Response<bool>> UpdateAsync(int id, SupplierUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var supplier = _mapper.Map<Supplier>(obj);
                response.Data = await _supplierDomain.UpdateAsync(id, supplier);
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
                response.Data = await _supplierDomain.DeleteAsync(id);
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

        public async Task<Response<IEnumerable<SupplierDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<SupplierDTO>>();
            try
            {
                var suppliers = await _supplierDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<SupplierDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<SupplierDTO>>();
            try
            {
                var suppliers = await _supplierDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<SupplierDTO>> GetByIdAsync(int id)
        {
            var response = new Response<SupplierDTO>();
            try
            {
                var supplier = await _supplierDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<SupplierDTO>(supplier);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<SupplierDTO>> GetByNameAsync(string name)
        {
            var response = new Response<SupplierDTO>();
            try
            {
                var supplier = await _supplierDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<SupplierDTO>(supplier);
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
