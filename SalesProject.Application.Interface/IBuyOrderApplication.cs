using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IBuyOrderApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(BuyOrderCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, BuyOrderUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<BuyOrderDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<BuyOrderDTO>>> GetAllAsync();
        Task<Response<PagedList<BuyOrderDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);

        Task<Response<bool>> GenerateBuyBasedOnBuyOrder(int id);
        #endregion
    }
}
