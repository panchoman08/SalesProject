using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly FerreteriaDbContext _context;

        public ProductRepository(FerreteriaDbContext context) 
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(Product obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Product obj)
        {
            var update = _context.Update(obj);
            await _context.SaveChangesAsync();

            return update != null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == id);
            var delete = _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(x => x.Category)
                                            .Include(x => x.Brand)
                                            .Include(x => x.Measure)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        public async Task<IQueryable<Product>> GetAllAsync()
        {
            IQueryable<Product> queryable = _context.Products.Include(x => x.Brand)
                                                .Include(x => x.Measure)
                                                .Include(x => x.Status) 
                                                .Include(x => x.Category); 
            return queryable;
        }
        #endregion
    }
}
