using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IProductMeasureApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductMeasureCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, ProductMeasureUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<ProductMeasureDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<ProductMeasureDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<ProductMeasureDTO>>> GetAllAsync();
        Task<Response<PagedList<ProductMeasureDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
