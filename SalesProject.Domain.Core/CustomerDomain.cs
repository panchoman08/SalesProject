using SalesProject.Domain.Interface;
using SalesProject.Domain.Entity;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models.pagination;
using System.Security.Cryptography.X509Certificates;
using SalesProject.Transversal.Common;

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
            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a customer created with the same nit and name.");
            }

            return await _genericCustomerRepo.InsertAsync(obj);
        }

        public async Task<bool> RegisterExists(Customer obj)
        {
            var queryable = await _genericCustomerRepo.GetAllAsync();
            var exist = await queryable.AnyAsync(x => x.Nit == obj.Nit && x.Name == obj.Name);

            return exist;
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

        public async Task<IQueryable<Customer>> GetAllWithPagingAsync()
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