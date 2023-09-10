using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ISaleDomain
    {
        #region async methods
        Task<bool> InsertAsync(Sale obj);
        Task<bool> UpdateAsync(int id, Sale obj);
        Task<bool> DeleteAsync(int id);
        Task<Sale> GetByIdAsync(int id);
        Task<IQueryable<Sale>> GetAllAsync();
        Task<IQueryable<Sale>> GetAllWithPagingAsync();
        Task<bool> IsASaleDocument(int id);
        Task<bool> RegisterExists(Sale obj);
        Task<bool> HasSaleReturnGenerated(int id);
        #endregion
    }
}
