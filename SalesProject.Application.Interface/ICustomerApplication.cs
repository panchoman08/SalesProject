using SalesProject.Application.DTO.customer.customer;
using SalesProject.Transversal.Common;
using System.Threading.Tasks;

namespace SalesProject.Application.Interface
{
    public interface ICustomerApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CustomerCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, CustomerUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CustomerDTO>> GetByIdAsync(int id);
        Task<Response<CustomerDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
        #endregion
    }
}
