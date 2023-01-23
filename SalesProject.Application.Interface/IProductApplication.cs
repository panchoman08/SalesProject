using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.product.product;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Interface
{
    public interface IProductApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, ProductUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<ProductDTO>> GetByIdAsync(int id);
        Task<Response<ProductDTO>> GetByNameAsync(string name);
        Task<Response<ProductDTO>> GetBySkuAsync(string sku);
        Task<Response<IEnumerable<ProductDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<ProductDTO>>> GetAllAsync();
        #endregion
    }
}
