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
    public class SupplierRepository : IGenericRepository<Supplier>
    {
        private readonly FerreteriaDbContext _context;
        public SupplierRepository() 
        {
            _context= new FerreteriaDbContext();
        }
        #region async methods
        public async Task<bool> InsertAsync(Supplier obj)
        {
            var insert = _context.Add(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Supplier obj)
        {
            var supplier = await _context.Suppliers.SingleAsync(x => x.Id == id);

            supplier.Nit = obj.Nit;
            supplier.Name = obj.Name;
            supplier.Address = obj.Address;
            supplier.Phone = obj.Phone;
            supplier.CategoryId = obj.CategoryId;

            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);

            var delete =_context.Remove(supplier);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Supplier> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
            return supplier;
        }
        public async Task<IQueryable<Supplier>> GetAllAsync()
        {
            IQueryable<Supplier> suppliers = _context.Suppliers.Include(x => x.Category);
            return suppliers;
        }
        #endregion
    }
}
