using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_return.sale_return;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ISaleReturnApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SaleReturnCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, SaleReturnUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<SaleReturnDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<SaleReturnDTO>>> GetAllAsync();
        Task<Response<PagedList<SaleReturnDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }

}
