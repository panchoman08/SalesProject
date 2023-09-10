using SalesProject.Domain.Entity.Models;

namespace SalesProject.Domain.Interface
{
    public interface ISalePriceCategoryDomain
    {
        #region async methods
        Task<bool> InsertAsync(CategorySalePrice obj);
        Task<bool> UpdateAsync(int id, CategorySalePrice obj);
        Task<bool> DeleteAsync(int id);
        Task<CategorySalePrice> GetByIdAsync(int id);
        Task<CategorySalePrice> GetByNameAsync(string name);
        Task<IEnumerable<CategorySalePrice>> GetAllThatContainsName(string name);
        Task<IQueryable<CategorySalePrice>> GetAllAsync();

        #endregion
    }
}
