using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ISaleReturnDomain
    {
        #region async methods
        Task<bool> InsertAsync(SaleReturn obj);
        Task<bool> UpdateAsync(int id, SaleReturn obj);
        Task<bool> DeleteAsync(int id);
        Task<SaleReturn> GetByIdAsync(int id);
        Task<IQueryable<SaleReturn>> GetAllAsync();
        Task<IQueryable<SaleReturn>> GetAllWithPagingAsync();
        Task<bool> IsASaleReturnDocument(int id);
        Task<bool> RegisterExists(SaleReturn obj);
        #endregion
    }
}
