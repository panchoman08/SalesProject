using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductCategoryRepository : IGenericRepository<ProductCat>
    {
        private readonly FerreteriaDbContext _context;

        public ProductCategoryRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(ProductCat obj)
        {
            var insert = await _context.ProductCats.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }

        public async Task<bool> UpdateAsync(int id, ProductCat obj)
        {
            var category = await _context.ProductCats.FirstOrDefaultAsync(x => x.Id == id);

            category.Name = obj.Name;

            var update = _context.ProductCats.Update(category);
            await _context.SaveChangesAsync();

            return update != null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.ProductCats.SingleAsync(x => x.Id == id);

            var delete = _context.ProductCats.Remove(category);
            await _context.SaveChangesAsync();

            return delete != null;
        }

        public async Task<ProductCat> GetByIdAsync(int id)
        {
            var category = await _context.ProductCats.FirstOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public async Task<IQueryable<ProductCat>> GetAllAsync()
        {
            IQueryable<ProductCat> queryable = _context.ProductCats;
            return queryable;
        }
    }
}
