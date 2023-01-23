using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ISupplierCatDomain
    {
        #region async methods
        Task<bool> InsertAsync(SupplierCat obj);
        Task<bool> UpdateAsync(int id, SupplierCat obj);
        Task<bool> DeleteAsync(int id);
        Task<SupplierCat> GetByIdAsync(int id);
        Task<SupplierCat> GetByNameAsync(string name);
        Task<IEnumerable<SupplierCat>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<SupplierCat>> GetAllAsync();
        #endregion
    }
}
