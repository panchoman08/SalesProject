using SalesProject.Application.DTO.cellar_transfer.cellar_transfer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ICellarTransferApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CellarTransferCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, CellarTransferUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CellarTransferDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<CellarTransferDTO>>> GetAllAsync();
        Task<Response<PagedList<CellarTransferDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
