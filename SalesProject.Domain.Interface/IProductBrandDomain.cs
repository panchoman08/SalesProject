using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IProductBrandDomain
    {
        #region async methods
        Task<bool> InsertAsync(Brand obj);
        Task<bool> UpdateAsync(int id, Brand obj);
        Task<bool> DeleteAsync(int id);
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> GetByNameAsync(string name);
        Task<IQueryable<Brand>> GetAllAsync();
        #endregion
    }
}
