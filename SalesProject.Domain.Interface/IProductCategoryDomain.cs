using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IProductCategoryDomain
    {
        #region async methods
        Task<bool> InsertAsync(ProductCat obj);
        Task<bool> UpdateAsync(int id, ProductCat obj);
        Task<bool> DeleteAsync(int id);
        Task<ProductCat> GetByIdAsync(int id);
        Task<IEnumerable<ProductCat>> GetAllThatContainsNameAsync(string name);
        Task<IQueryable<ProductCat>> GetAllAsync();
        Task<IQueryable<ProductCat>> GetAllWithPagingAsync();
        Task<bool> RegisterExist(ProductCat obj);
        #endregion
    }
}
