using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class CustomerCatRepository : IGenericRepository<CustomerCat>
    {
        private readonly FerreteriaDbContext _context;
        public CustomerCatRepository() 
        {
            _context= new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(CustomerCat obj)
        {
            var insert = _context.Add(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, CustomerCat obj)
        {
            var category = await _context.CustomerCats.FirstOrDefaultAsync(x => x.Id == id);

            category.Name = obj.Name;

            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.CustomerCats.SingleAsync(x => x.Id == id);
            var delete = _context.CustomerCats.Remove(customer);
            await _context.SaveChangesAsync();

            return delete != null;
        }

        public async Task<CustomerCat> GetByIdAsync(int id)
        {
            var customerCat = await _context.CustomerCats.FirstOrDefaultAsync(x => x.Id == id);
            return customerCat;
        }
        public async Task<IQueryable<CustomerCat>> GetAllAsync()
        {
            IQueryable<CustomerCat> queryable = _context.CustomerCats;
            return queryable;
        }
        
        #endregion
    }
}
