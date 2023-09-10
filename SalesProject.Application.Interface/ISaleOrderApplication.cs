using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.sale_order.sale_order;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ISaleOrderApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SaleOrderCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, SaleOrderUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<SaleOrderDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<SaleOrderDTO>>> GetAllAsync();
        Task<Response<PagedList<SaleOrderDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);

        Task<Response<bool>> GenerateSaleBasedOnSaleOrder(int id);
        #endregion
    }
}
