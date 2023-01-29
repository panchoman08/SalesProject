using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Core
{
    public class SupplierCatDomain : ISupplierCatDomain
    {
        private readonly IGenericRepository<SupplierCat> _genericSupplierCatRepo;
        public SupplierCatDomain(IGenericRepository<SupplierCat> genericRepository) 
        {
            _genericSupplierCatRepo= genericRepository;
        }
        #region async methods
        public async Task<bool> InsertAsync(SupplierCat obj)
        {
            if (await GetByNameAsync(obj.Name) != null)
            {
                throw new Exception("There is already a supplier category created with the same name.");
            }
            return await _genericSupplierCatRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, SupplierCat obj)
        {
            return await _genericSupplierCatRepo.UpdateAsync(id, obj);    
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericSupplierCatRepo.DeleteAsync(id);
        }
        public async Task<SupplierCat> GetByIdAsync(int id)
        {
            return await _genericSupplierCatRepo.GetByIdAsync(id);
        }
        public async Task<SupplierCat> GetByNameAsync(string name)
        {
            var supplierCat = await _genericSupplierCatRepo.GetAllAsync();
            return await supplierCat.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<IEnumerable<SupplierCat>> GetAllTthatContainsNameAsync(string name)
        {
            var supplierCats = await _genericSupplierCatRepo.GetAllAsync();
            return await supplierCats.Where(x => x.Name.Contains(name)).ToListAsync();
        }
        public async Task<IQueryable<SupplierCat>> GetAllAsync()
        {
            return await _genericSupplierCatRepo.GetAllAsync();
        }
        #endregion
    }
}
