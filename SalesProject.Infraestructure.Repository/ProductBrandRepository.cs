using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductBrandRepository : IGenericRepository<Brand>
    {
        private readonly FerreteriaDbContext _context;

        public ProductBrandRepository(FerreteriaDbContext context) 
        {
            _context = context;
        }
        #region async methods
        public async Task<bool> InsertAsync(Brand obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Brand obj)
        {
            var update = _context.Update(obj);
            await _context.SaveChangesAsync();

            return update != null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _context.Brands.SingleAsync(x => x.Id == id);
            var delete = _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Brand> GetByIdAsync(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
            return brand;
        }
        public async Task<IQueryable<Brand>> GetAllAsync()
        {
            IQueryable<Brand> queryable = _context.Brands;
            return queryable;
        }
        #endregion
    }
}
