using AutoMapper;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class CellarApplication : ICellarApplication
    {
        private readonly ICellarDomain _cellarDomain;
        private readonly IMapper _mapper;

        public CellarApplication(ICellarDomain cellarDomain, IMapper mapper) 
        {
            _cellarDomain = cellarDomain;
            _mapper = mapper;
        }
        #region async methods
        public async Task<Response<bool>> InsertAsync(CellarCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var cellar = _mapper.Map<Cellar>(obj);
                response.Data = await _cellarDomain.InsertAsync(cellar);
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
        public async Task<Response<bool>> UpdateAsync(int id, CellarUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var cellar = _mapper.Map<Cellar>(obj);
                response.Data = await _cellarDomain.UpdateAsync(id, cellar);
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
                response.Data = await _cellarDomain.DeleteAsync(id);
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
        public async Task<Response<CellarDTO>> GetByIdAsync(int id)
        {
            var response = new Response<CellarDTO>();
            try
            {
                var cellar = await _cellarDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<CellarDTO>(cellar);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<CellarDTO>> GetByNameAsync(string name)
        {
            var response = new Response<CellarDTO>();
            try
            {
                var cellar = await _cellarDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<CellarDTO>(cellar);
                response.IsSuccess= true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
        public async Task<Response<IEnumerable<CellarDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CellarDTO>>();
            try
            {
                var cellars = await _cellarDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CellarDTO>>(cellars);
                response.IsSuccess= true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message= ex.Message;
            }
            return response;
        }
        #endregion
    }
}
