using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Infraestructure.Repository;

namespace SalesProject.Domain.Core
{
    public class ProductBrandDomain : IProductBrandDomain
    {
        private readonly IGenericRepository<Brand> _genericProductBrandRepo;

        public ProductBrandDomain(IGenericRepository<Brand> genericProductBrandRepo) 
        {
            _genericProductBrandRepo = genericProductBrandRepo;
        }
        #region async methods
        public async Task<bool> InsertAsync(Brand obj)
        {
            return await _genericProductBrandRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, Brand obj)
        {
            return await _genericProductBrandRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id) 
        { 
            return await _genericProductBrandRepo.DeleteAsync(id);
        }
        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _genericProductBrandRepo.GetByIdAsync(id);
        }
        public async Task<Brand> GetByNameAsync(string name)
        {
            var queryable = await _genericProductBrandRepo.GetAllAsync();
            return await queryable.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Brand>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericProductBrandRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }
        public async Task<IQueryable<Brand>> GetAllAsync()
        {
            return await _genericProductBrandRepo.GetAllAsync();
        }

        
        #endregion
    }
}
