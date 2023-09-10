using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IBuyReturnDomain
    {
        #region async methods
        Task<bool> InsertAsync(BuyReturn obj);
        Task<bool> UpdateAsync(int id, BuyReturn obj);
        Task<bool> DeleteAsync(int id);
        Task<BuyReturn> GetByIdAsync(int id);
        Task<IQueryable<BuyReturn>> GetAllAsync();
        Task<IQueryable<BuyReturn>> GetAllWithPagingAsync();
        Task<bool> IsABuyReturnDocument(int id);
        Task<bool> RegisterExists(BuyReturn obj);
        #endregion
    }
}
