using SalesProject.Domain.Interface;
using SalesProject.Domain.Entity;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace SalesProject.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly IGenericRepository<Customer> _genericCustomerRepo;
        public CustomerDomain(IGenericRepository<Customer> genericCustomerRepo)
        {
            _genericCustomerRepo = genericCustomerRepo;
        }

        public async Task<bool> InsertAsync(Customer obj)
        {
            /*var customerQuerying = await _genericCustomerRepo.GetAllAsync();
            var customerByNitAndName = await customerQuerying.Where(x => x.Name.Equals(obj.Name) && x.Nit.Equals(obj.Nit)).ToListAsync();

            if (customerByNitAndName.Count >  0)
            {
                return false;
            }
            */
            return await _genericCustomerRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, Customer obj)
        {
            return await _genericCustomerRepo.UpdateAsync(id, obj);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _genericCustomerRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return await _genericCustomerRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllTthatContainsNameAsync(string name)
        {
            var customerQueryable = await _genericCustomerRepo.GetAllAsync();
            var customers = customerQueryable.Where(x => x.Name.Contains(name)).ToList();
            
            return customers;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _genericCustomerRepo.GetByIdAsync(id);
        }

        public async Task<Customer> GetByNameAsync(string name)
        {
            var customerQueryable = await _genericCustomerRepo.GetAllAsync();
            var customer = customerQueryable.FirstOrDefault(x => x.Name.Equals(name));

            return customer;
        }

    }
}