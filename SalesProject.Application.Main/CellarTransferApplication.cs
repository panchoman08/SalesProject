using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Main
{
    public class CellarTransferApplication : ICellarTransferApplication
    {
        private readonly ICellarTransferDomain _cellarTransferDomain;
        private readonly IMapper _mapper;

        public CellarTransferApplication(ICellarTransferDomain cellarTransferDomain,
            IMapper mapper)
        {
            _cellarTransferDomain = cellarTransferDomain;
            _mapper = mapper;
        }

        #region async methods
        public async Task<Response<bool>> InsertAsync(CellarTransferCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var cellarTrans = _mapper.Map<CellarTransfer>(obj);
                response.Data = await _cellarTransferDomain.InsertAsync(cellarTrans);
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
        public async Task<Response<bool>> UpdateAsync(int id, CellarTransferUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var cellarTrans = _mapper.Map<CellarTransfer>(obj);
                response.Data = await _cellarTransferDomain.UpdateAsync(id, cellarTrans);
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
                response.Data = await _cellarTransferDomain.DeleteAsync(id);
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
        public async Task<Response<CellarTransferDTO>> GetByIdAsync(int id)
        {
            var response = new Response<CellarTransferDTO>();
            try
            {
                var cellarTransfer = await _cellarTransferDomain.GetByIdAsync(id);
                response.Data = _mapper.Map<CellarTransferDTO>(cellarTransfer);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }
        public async Task<Response<IEnumerable<CellarTransferDTO>>> GetAllAsync() 
        {
            var response = new Response<IEnumerable<CellarTransferDTO>>();

            try
            {
                var cellarTransfer = await _cellarTransferDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CellarTransferDTO>>(cellarTransfer);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<PagedList<CellarTransferDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO)
        {
            var response = new Response<PagedList<CellarTransferDTO>>();
            try
            {
                var cellarTransfers = await _cellarTransferDomain.GetAllWithPagingAsync();
                IEnumerable<CellarTransferDTO> cellarTransferIE = _mapper.Map<IEnumerable<CellarTransferDTO>>(await cellarTransfers.ToListAsync());

                response.Data = PagedList<CellarTransferDTO>.ToPagedList(cellarTransferIE, paginationParametersDTO.PageNumber, paginationParametersDTO.PageSize);
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
