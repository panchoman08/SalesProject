using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.product.product;
using SalesProject.Transversal.Common;


namespace SalesProject.Application.Interface
{
    public interface IProductBrandApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(ProductCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, CustomerUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CustomerDTO>> GetByIdAsync(int id);
        Task<Response<CustomerDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        #endregion
    }
}
