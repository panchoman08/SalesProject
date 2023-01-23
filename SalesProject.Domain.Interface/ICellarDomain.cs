using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface ICellarDomain
    {
        #region async methods
        Task<bool> InsertAsync(Cellar obj);
        Task<bool> UpdateAsync(int id, Cellar obj);
        Task<bool> DeleteAsync(int id);
        Task<Cellar> GetByIdAsync(int id);
        Task<Cellar> GetByNameAsync(string name);
        Task<IQueryable<Cellar>> GetAllAsync();
        #endregion
    }
}
