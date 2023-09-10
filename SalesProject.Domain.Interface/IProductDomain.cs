using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IProductDomain
    {
        #region async methods
        Task<bool> InsertAsync(Product obj);
        Task<bool> UpdateAsync(int id, Product obj);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetBySkuAsync(string sku);
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetAllThatContainsNameAsync(string name);
        Task<IEnumerable<Product>> GetAllThatContainsSkuAsync(string sku);
        Task<IQueryable<Product>> GetAllAsync();
        Task<IQueryable<Product>> GetAllWithPagingAsync();
        #endregion
    }
}
