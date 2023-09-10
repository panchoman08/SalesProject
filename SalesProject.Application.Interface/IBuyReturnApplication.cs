using SalesProject.Application.DTO.buy_return.buy_return;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IBuyReturnApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(BuyReturnCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, BuyReturnUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<BuyReturnDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<BuyReturnDTO>>> GetAllAsync();
        Task<Response<PagedList<BuyReturnDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
