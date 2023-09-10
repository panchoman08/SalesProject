using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ICellarTransferDomain
    {
        #region async methods
        Task<bool> InsertAsync(CellarTransfer obj);
        Task<bool> UpdateAsync(int id, CellarTransfer obj);
        Task<bool> DeleteAsync(int id);
        Task<CellarTransfer> GetByIdAsync(int id);
        Task<IQueryable<CellarTransfer>> GetAllAsync();
        Task<IQueryable<CellarTransfer>> GetAllWithPagingAsync();
        Task<bool> IsACellarTransferDocument(int id);
        Task<bool> RegisterExists(CellarTransfer obj);
        #endregion
    }
}
