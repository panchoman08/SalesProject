using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ICustomerCatDomain
    {
        #region async methods
        Task<bool> InsertAsync(CustomerCat obj);
        Task<bool> UpdateAsync(int id, CustomerCat obj);
        Task<bool> DeleteAsync(int id);
        Task<CustomerCat> GetByIdAsync(int id);
        Task<CustomerCat> GetByNameAsync(string name);
        Task<IEnumerable<CustomerCat>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<CustomerCat>> GetAllAsync();
        #endregion
    }
}
