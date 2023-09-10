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
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);

            customer.Nit = (!string.IsNullOrEmpty(obj.Nit)) ? obj.Nit : customer.Nit;
            customer.Cui = (!string.IsNullOrEmpty(obj.Cui)) ? obj.Cui : customer.Cui;
            customer.Name = (!string.IsNullOrEmpty(obj.Name)) ? obj.Name : customer.Name;
            customer.Address = (!string.IsNullOrEmpty(obj.Address)) ? obj.Address : customer.Address;
            customer.Phone = (!string.IsNullOrEmpty(obj.Phone)) ? obj.Phone : customer.Phone;
            customer.Email = (!string.IsNullOrEmpty(obj.Email)) ? obj.Email : customer.Email;
            customer.CreditDays = (obj.CreditDays != null) ? obj.CreditDays : customer.CreditDays;
            customer.CreditLimit = (obj.CreditLimit != null) ? obj.CreditLimit : customer.CreditLimit;
            customer.Defaulter = obj.Defaulter;
            customer.CategoryId = customer.CategoryId;

            var save = await _context.SaveChangesAsync();

            return save > 0;
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