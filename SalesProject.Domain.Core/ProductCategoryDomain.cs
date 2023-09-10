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
    public class ProductCategoryDomain : IProductCategoryDomain
    {
        private readonly IGenericRepository<ProductCat> _genericProductCatRepo;

        public ProductCategoryDomain(IGenericRepository<ProductCat> genericRepository)
        {
            _genericProductCatRepo = genericRepository;
        }
        public async Task<bool> InsertAsync(ProductCat obj)
        {
            if (await RegisterExist(obj))
            {
                throw new Exception($"There is already register a product category with the same name.");
            }

            return await _genericProductCatRepo.InsertAsync(obj); 
        }
        public async Task<bool> UpdateAsync(int id, ProductCat obj)
        {
            return await _genericProductCatRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericProductCatRepo.DeleteAsync(id);
        }

        public Task<IQueryable<ProductCat>> GetAllAsync()
        {
            return _genericProductCatRepo.GetAllAsync();
        }
        public Task<IQueryable<ProductCat>> GetAllWithPagingAsync()
        {
            return _genericProductCatRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ProductCat>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericProductCatRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<ProductCat> GetByIdAsync(int id)
        {
            return await _genericProductCatRepo.GetByIdAsync(id);
        }

        public async Task<bool> RegisterExist(ProductCat obj)
        {
            var queryable = await _genericProductCatRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.Name == obj.Name);
        }

        
    }
}
