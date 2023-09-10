using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.pagination;
using SalesProject.Transversal.Common;

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
        Task<Response<PagedList<CustomerDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParameters);
        #endregion
    }
}
