using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IMinMaxProductUnitsDomain
    {
        #region async methods
        Task<bool> InsertAsync(MinMaxProd obj);
        Task<bool> UpdateAsync(int id, MinMaxProd obj);
        Task<bool> DeleteAsync(int id);
        Task<MinMaxProd> GetByIdAsync(int id);
        Task<IQueryable<MinMaxProd>> GetAllAsync();
        Task<IQueryable<MinMaxProd>> GetAllWithPagingAsync();
        Task<bool> RegisterExist(MinMaxProd obj);
        Task<bool> IsAValidCellarId(int cellarId);
        bool AreManimumAndMaximumValid(int min, int max);
        #endregion
    }
}
