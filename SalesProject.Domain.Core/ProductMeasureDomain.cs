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
    public class ProductMeasureDomain : IProductMeasureDomain
    {
        private readonly IGenericRepository<Measure> _genericMeasureRepo;

        public ProductMeasureDomain(IGenericRepository<Measure> genericRepository)
        {
            _genericMeasureRepo = genericRepository;
        }
        public async Task<bool> InsertAsync(Measure obj)
        {
            if (await RegisterExist(obj))
            {
                throw new Exception("There is already created a measure with the same name.");
            }

            return await _genericMeasureRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, Measure obj)
        {
            return await _genericMeasureRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericMeasureRepo.DeleteAsync(id); 
        }

        public async Task<IQueryable<Measure>> GetAllAsync()
        {
            return await _genericMeasureRepo.GetAllAsync();
        }

        public async Task<IQueryable<Measure>> GetAllWithPagingAsync()
        {
            return await _genericMeasureRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Measure>> GetAllThatContainsNameAsync(string name)
        {
            var queryable = await _genericMeasureRepo.GetAllAsync();
            return await queryable.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Measure> GetByIdAsync(int id)
        {
            return await _genericMeasureRepo.GetByIdAsync(id);
        }

        public async Task<bool> RegisterExist(Measure obj)
        {
            var queryable = await _genericMeasureRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.Name == obj.Name);
        }

        
    }
}
