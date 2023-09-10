using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class SalePriceCategoryRepository : IGenericRepository<CategorySalePrice>
    {
        private readonly FerreteriaDbContext _context;

        public SalePriceCategoryRepository() 
        {
            _context = new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(CategorySalePrice obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, CategorySalePrice obj)
        {
            var salePriceCategory = await _context.CategorySalePrices.SingleAsync(x => x.Id == id);

            salePriceCategory.Name = obj.Name;
            salePriceCategory.Description = obj.Description;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var salePriceCategory = await _context.CategorySalePrices.SingleAsync(x => x.Id == id);
            var delete = _context.CategorySalePrices.Remove(salePriceCategory);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<CategorySalePrice> GetByIdAsync(int id)
        {
            var salePriceCategory = await _context.CategorySalePrices.FirstOrDefaultAsync(x => x.Id == id);
            return salePriceCategory;
        }
        public async Task<IQueryable<CategorySalePrice>> GetAllAsync()
        {
            IQueryable<CategorySalePrice> queryable = _context.CategorySalePrices;
            return queryable;
        }
        #endregion
    }
}
