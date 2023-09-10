using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Repository
{
    public class ProductMeasureRepository : IGenericRepository<Measure>
    {
        private readonly FerreteriaDbContext _context;

        public ProductMeasureRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(Measure obj)
        {
            var insert = await _context.Measures.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }

        public async Task<bool> UpdateAsync(int id, Measure obj)
        {
            var measure = await _context.Measures.SingleAsync(x => x.Id == id);

            measure.Name = obj.Name;

            var update = _context.Measures.Update(measure);
            await _context.SaveChangesAsync();

            return update != null;  
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var measure = await _context.Measures.SingleAsync(x => x.Id == id);

            var delete = _context.Measures.Remove(measure);
            await _context.SaveChangesAsync();

            return delete != null;
        }

        public async Task<IQueryable<Measure>> GetAllAsync()
        {
            IQueryable<Measure> queryable = _context.Measures;
            return queryable;
        }

        public async Task<Measure> GetByIdAsync(int id)
        {
            var measure = await _context.Measures.FirstOrDefaultAsync(x => x.Id == id);
            return measure;
        }

        
    }
}
