using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IProductMeasureDomain
    {
        #region async methods
        Task<bool> InsertAsync(Measure obj);
        Task<bool> UpdateAsync(int id, Measure obj);
        Task<bool> DeleteAsync(int id);
        Task<Measure> GetByIdAsync(int id);
        Task<IEnumerable<Measure>> GetAllThatContainsNameAsync(string name);
        Task<IQueryable<Measure>> GetAllAsync();
        Task<IQueryable<Measure>> GetAllWithPagingAsync();
        Task<bool> RegisterExist(Measure obj);
        #endregion
    }
}
