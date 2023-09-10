using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ISaleOrderDomain
    {
        #region async methods
        Task<bool> InsertAsync(SaleOrder obj);
        Task<bool> UpdateAsync(int id, SaleOrder obj);
        Task<bool> DeleteAsync(int id);
        Task<SaleOrder> GetByIdAsync(int id);
        Task<IQueryable<SaleOrder>> GetAllAsync();
        Task<IQueryable<SaleOrder>> GetAllWithPagingAsync();

        Task<bool> RegisterExists(SaleOrder obj);

        Task<bool> IsASaleOrderDocument(int id);
        Task<bool> IsASaleDocument(int id);

        Task<bool> HasSaleGenerated(int id);
        Task<bool> GenerateSaleBasedOnSaleOrder(Sale obj);
        #endregion
    }
}
