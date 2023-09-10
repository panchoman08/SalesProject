using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class SupplierCatRepository : IGenericRepository<SupplierCat>
    {
        private readonly FerreteriaDbContext _context;
        public SupplierCatRepository() 
        {
            _context= new FerreteriaDbContext();
        }
        #region async methods
        public async Task<bool> InsertAsync(SupplierCat obj)
        {
            var insert = _context.Add(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, SupplierCat obj)
        {
            var category = await _context.SupplierCats.SingleOrDefaultAsync(x => x.Id == id);

            category.Name = obj.Name;
            var save = await _context.SaveChangesAsync();

            return save > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.SupplierCats.SingleOrDefaultAsync(x => x.Id == id);
            var delete = _context.Remove(category);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<SupplierCat> GetByIdAsync(int id)
        {
            var category = await _context.SupplierCats.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }
        public async Task<IQueryable<SupplierCat>> GetAllAsync()
        {
            IQueryable<SupplierCat> queryable = _context.SupplierCats;
            return queryable;
        }
        #endregion
    }
}
