using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.min_max;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IMinMaxProductUnitsApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(MinMaxProductUnitsCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, MinMaxProductUnitsUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<MinMaxProductUnitsDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<MinMaxProductUnitsDTO>>> GetAllAsync();
        Task<Response<PagedList<MinMaxProductUnitsDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
