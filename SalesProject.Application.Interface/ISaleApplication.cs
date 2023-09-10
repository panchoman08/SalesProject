using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale.sale;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ISaleApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SaleCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, SaleUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<SaleDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<SaleDTO>>> GetAllAsync();
        Task<Response<PagedList<SaleDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
