using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using System.Runtime.InteropServices;

namespace SalesProject.Domain.Core
{
    public class MinMaxProductUnitsDomain : IMinMaxProductUnitsDomain
    {
        private readonly IGenericRepository<MinMaxProd> _genericMinMaxProdsRepo;
        private readonly IGenericRepository<Cellar> _genericCellarRepo;

        public MinMaxProductUnitsDomain(IGenericRepository<MinMaxProd> genericMinMaxProdsRepo, 
                IGenericRepository<Cellar> genericCellarRepo)
        {
            _genericMinMaxProdsRepo = genericMinMaxProdsRepo;
            _genericCellarRepo = genericCellarRepo;
        }

        public async Task<bool> InsertAsync(MinMaxProd obj)
        {
            if (!await IsAValidCellarId(obj.CellarId))
            {
                throw new Exception("Please enter a valid cellar id.");
            }

            if (!AreManimumAndMaximumValid(obj.Minimum, obj.Maximum))
            {
                throw new Exception("Maximum must be grather than minimum value.");
            }

            if (await RegisterExist(obj))
            {
                throw new Exception("There is already a min max register to this product and cellar.");
            }

            return await _genericMinMaxProdsRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, MinMaxProd obj)
        {
            if (!await IsAValidCellarId(obj.CellarId))
            {
                throw new Exception("Please enter a valid cellar id.");
            }

            if (!AreManimumAndMaximumValid(obj.Minimum, obj.Maximum))
            {
                throw new Exception("Maximum must be grather than minimum value.");
            }

            return await _genericMinMaxProdsRepo.UpdateAsync(id, obj);  
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericMinMaxProdsRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<MinMaxProd>> GetAllAsync()
        {
            return await _genericMinMaxProdsRepo.GetAllAsync();
        }

        public async Task<IQueryable<MinMaxProd>> GetAllWithPagingAsync()
        {
            return await _genericMinMaxProdsRepo.GetAllAsync();
        }

        public async Task<MinMaxProd> GetByIdAsync(int id)
        {
            return await _genericMinMaxProdsRepo.GetByIdAsync(id);
        }

        public async Task<bool> RegisterExist(MinMaxProd obj)
        {
            var queryable = await _genericMinMaxProdsRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.ProductId == obj.ProductId && x.CellarId == obj.CellarId); 

        }

        public async Task<bool> IsAValidCellarId(int cellarId)
        {
            var cellar = await _genericCellarRepo.GetByIdAsync(cellarId);
            return cellar != null;
        }

        public bool AreManimumAndMaximumValid(int min, int max)
        {
            return max > min;
        }

    }
}
