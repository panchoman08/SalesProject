using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;
using System.Security.Cryptography.X509Certificates;

namespace SalesProject.Infraestructure.Repository
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly FerreteriaDbContext _context;
        public CustomerRepository() 
        {
            _context = new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(Customer obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Customer obj)
        {
            var update = _context.Update(obj);
            await _context.SaveChangesAsync();

            return update != null;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.SingleAsync(x => x.Id == id);
            var delete = _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }
        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            IQueryable<Customer> customers = _context.Customers.Include(x => x.Category);
            return customers;
        }
        #endregion
    }
}