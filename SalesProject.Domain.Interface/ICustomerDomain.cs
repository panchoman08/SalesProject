using SalesProject.Domain.Entity;
using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ICustomerDomain
    {
        #region async methods
        Task<bool> InsertAsync(Customer obj);
        Task<bool> UpdateAsync(int id, Customer obj);
        Task<bool> DeleteAsync(int id);
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByNameAsync(string name);
        Task<IEnumerable<Customer>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<Customer>> GetAllAsync();

        Task<bool> RegisterExists(Customer obj);
        #endregion
    }
}
