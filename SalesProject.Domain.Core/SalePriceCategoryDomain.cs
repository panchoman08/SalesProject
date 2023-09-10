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
    public class SalePriceCategoryDomain : ISalePriceCategoryDomain
    {
        private readonly IGenericRepository<CategorySalePrice> _genericSalePriceCatRepo;
        public SalePriceCategoryDomain(IGenericRepository<CategorySalePrice> genericRepository) 
        {
            _genericSalePriceCatRepo = genericRepository;
        }

        #region async methods
        public async Task<bool> InsertAsync(CategorySalePrice obj)
        {
            if (await GetByNameAsync(obj.Name) != null)
            {
                throw new Exception("There is already a sale price category created with the same name.");
            }
            return await _genericSalePriceCatRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, CategorySalePrice obj)
        {
            return await _genericSalePriceCatRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericSalePriceCatRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<CategorySalePrice>> GetAllAsync()
        {
            return await _genericSalePriceCatRepo.GetAllAsync();
        }

        public async Task<CategorySalePrice> GetByIdAsync(int id)
        {
            return await _genericSalePriceCatRepo.GetByIdAsync(id);
        }

        public async Task<CategorySalePrice> GetByNameAsync(string name)
        {
            var queryable = await _genericSalePriceCatRepo.GetAllAsync();
            var salePriceCategory = await queryable.FirstOrDefaultAsync(x => x.Name == name);

            return salePriceCategory;
        }

        public async Task<IEnumerable<CategorySalePrice>> GetAllThatContainsName(string name)
        {
            var queryable = await _genericSalePriceCatRepo.GetAllAsync();
            var salePriceCategories = await queryable.Where(x => x.Name.Contains(name)).ToListAsync();

            return salePriceCategories;
        }
        #endregion
    }
}
