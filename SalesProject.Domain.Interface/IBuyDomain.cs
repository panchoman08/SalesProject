using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IBuyDomain
    {
        #region async methods
        Task<bool> InsertAsync(Buy obj);
        Task<bool> UpdateAsync(int id, Buy obj);
        Task<bool> DeleteAsync(int id);
        Task<Buy> GetByIdAsync(int id);
        Task<IQueryable<Buy>> GetAllAsync();
        Task<IQueryable<Buy>> GetAllWithPagingAsync();
        Task<bool> IsABuyDocument(int id);
        Task<bool> RegisterExists(Buy obj);
        #endregion
    }
}
