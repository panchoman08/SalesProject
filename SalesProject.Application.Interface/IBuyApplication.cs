using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IBuyApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(BuyCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, BuyUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<BuyDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<BuyDTO>>> GetAllAsync();
        Task<Response<PagedList<BuyDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
