using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.category;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IProductCategoryApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductCatCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, ProductCatUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<ProductCatDTO>> GetByIdAsync(int id);
        Task<Response<IEnumerable<ProductCatDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<ProductCatDTO>>> GetAllAsync();
        Task<Response<PagedList<ProductCatDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
