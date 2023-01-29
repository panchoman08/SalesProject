using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ISupplierDomain
    {
        #region async methods
        Task<bool> InsertAsync(Supplier obj);
        Task<bool> UpdateAsync(int id, Supplier obj);
        Task<bool> DeleteAsync(int id);
        Task<Supplier> GetByIdAsync(int id);
        Task<Supplier> GetByNameAsync(string name);
        Task<IEnumerable<Supplier>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<Supplier>> GetAllAsync();
        Task<bool> RegisterExists(Supplier obj);
        #endregion
    }
}
