using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Infraestructure.Repository
{
    public class MinMaxProductUnitsRepository : IGenericRepository<MinMaxProd>
    {
        private readonly FerreteriaDbContext _context;

        public MinMaxProductUnitsRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(MinMaxProd obj)
        {
            var insert = await _context.MinMaxProds.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }

        public async Task<bool> UpdateAsync(int id, MinMaxProd obj)
        {
            var minMaxProductUnits = await _context.MinMaxProds.SingleAsync(x => x.Id == id);

            minMaxProductUnits.ProductId = obj.ProductId;
            minMaxProductUnits.CellarId = obj.CellarId;
            minMaxProductUnits.Minimum = obj.Minimum;
            minMaxProductUnits.Maximum = obj.Maximum;

            var update = _context.MinMaxProds.Update(minMaxProductUnits);
            await _context.SaveChangesAsync();

            return update != null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var minMaxProductUnits = await _context.MinMaxProds.SingleAsync(x => x.Id == id);

            var delete = _context.MinMaxProds.Remove(minMaxProductUnits);
            await _context.SaveChangesAsync();

            return delete != null;
        }

        public async Task<IQueryable<MinMaxProd>> GetAllAsync()
        {
            var queryable =  _context.MinMaxProds;
            return queryable;
        }

        public async Task<MinMaxProd> GetByIdAsync(int id)
        {
            var minMaxProductUnits = await _context.MinMaxProds.FirstOrDefaultAsync(x => x.Id == id);
            return minMaxProductUnits;
        }

        
    }
}
