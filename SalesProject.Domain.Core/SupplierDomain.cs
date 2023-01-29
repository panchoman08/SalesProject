using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class SupplierDomain : ISupplierDomain
    {
        private readonly IGenericRepository<Supplier> _genericSupplierRepo;
        public SupplierDomain(IGenericRepository<Supplier> genericRepository) 
        {
            _genericSupplierRepo = genericRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(Supplier obj)
        {
            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a suppplier created with the same NIT and name.");
            }
            return await _genericSupplierRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, Supplier obj)
        {
            return await _genericSupplierRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericSupplierRepo.DeleteAsync(id);
        }

        public Task<IQueryable<Supplier>> GetAllAsync()
        {
            return _genericSupplierRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllTthatContainsNameAsync(string name)
        {
            var suppliers = await _genericSupplierRepo.GetAllAsync();
            return await suppliers.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _genericSupplierRepo.GetByIdAsync(id);
        }

        public async Task<Supplier> GetByNameAsync(string name)
        {
            var suppliers = await _genericSupplierRepo.GetAllAsync();
            return await suppliers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> RegisterExists(Supplier obj)
        {
            var queryable = await _genericSupplierRepo.GetAllAsync();
            var exist = await queryable.AnyAsync(x => x.Nit == obj.Nit && x.Name == obj.Name);

            return exist;
        }
        #endregion
    }
}
