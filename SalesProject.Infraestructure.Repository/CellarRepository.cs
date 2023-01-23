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
    public class CellarRepository : IGenericRepository<Cellar>
    {
        private readonly FerreteriaDbContext _context;
        public CellarRepository() 
        {
            _context = new FerreteriaDbContext();
        }
        #region async methods
        public async Task<bool> InsertAsync(Cellar obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Cellar obj)
        {
            var update = _context.Update(obj);
            await _context.SaveChangesAsync();

            return update != null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var cellar = await _context.Cellars.SingleAsync(x => x.Id == id);
            var delete = _context.Cellars.Remove(cellar);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Cellar> GetByIdAsync(int id)
        {
            var cellar = await _context.Cellars.FirstOrDefaultAsync(x => x.Id == id);
            return cellar;
        }
        public async Task<IQueryable<Cellar>> GetAllAsync()
        {
            IQueryable<Cellar> queryable = _context.Cellars;
            return queryable;
        }
        #endregion
    }
}
