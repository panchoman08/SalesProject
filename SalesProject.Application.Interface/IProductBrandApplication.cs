using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Interface
{
    public interface IProductBrandApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductBrandCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, ProductBrandUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<ProductBrandDTO>> GetByIdAsync(int id);
        Task<Response<ProductBrandDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<ProductBrandDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<ProductBrandDTO>>> GetAllAsync();
        Task<Response<PagedList<ProductBrandDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
