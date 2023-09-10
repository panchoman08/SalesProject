using SalesProject.Application.DTO.customer.category;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ICustomerCatApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CustomerCatCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, CustomerCatUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CustomerCatDTO>> GetByIdAsync(int id);
        Task<Response<CustomerCatDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CustomerCatDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<CustomerCatDTO>>> GetAllAsync();
        #endregion
    }
}
