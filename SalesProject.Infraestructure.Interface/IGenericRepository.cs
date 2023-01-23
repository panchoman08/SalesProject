using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Interface
{
    public interface IGenericRepository<T1>
    {
        #region async methods
        Task<bool> InsertAsync(T1 obj);
        Task<bool> UpdateAsync(int id, T1 obj);
        Task<bool> DeleteAsync(int id);
        Task<T1> GetByIdAsync(int id);
        Task<IQueryable<T1>> GetAllAsync();
        #endregion
    }
}
