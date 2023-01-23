using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using System;
using SalesProject.Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace SalesProject.Domain.Core
{
    public class CustomerCatDomain : ICustomerCatDomain
    {
        private readonly IGenericRepository<CustomerCat> _genericCustomerCatRepo;
        public CustomerCatDomain(IGenericRepository<CustomerCat> customerCatRepository) 
        {
            _genericCustomerCatRepo = customerCatRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(CustomerCat obj)
        {
            return await _genericCustomerCatRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, CustomerCat obj)
        {
            return await _genericCustomerCatRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericCustomerCatRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<CustomerCat>> GetAllAsync()
        {
            return await _genericCustomerCatRepo.GetAllAsync();
        }

        public async Task<IEnumerable<CustomerCat>> GetAllTthatContainsNameAsync(string name)
        {
            var customerCats = await _genericCustomerCatRepo.GetAllAsync();
            return await customerCats.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<CustomerCat> GetByIdAsync(int id)
        {
            return await _genericCustomerCatRepo.GetByIdAsync(id);
        }

        public async Task<CustomerCat> GetByNameAsync(string name)
        {
            var queryable = await _genericCustomerCatRepo.GetAllAsync();
            var customerCat = await queryable.FirstOrDefaultAsync(x => x.Name == name);

            return customerCat;
        }
        #endregion
    }
}
