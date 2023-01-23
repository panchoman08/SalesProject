using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class CellarDomain : ICellarDomain
    {
        private readonly IGenericRepository<Cellar> _genericCellarRepo;
        public CellarDomain(IGenericRepository<Cellar> genericRepository) 
        {
            _genericCellarRepo = genericRepository;
        }
        #region async methods
        public async Task<bool> InsertAsync(Cellar obj)
        {
            return await _genericCellarRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, Cellar obj)
        {
            return await _genericCellarRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericCellarRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<Cellar>> GetAllAsync()
        {
            return await _genericCellarRepo.GetAllAsync();
        }

        public async Task<Cellar> GetByIdAsync(int id)
        {
            return await _genericCellarRepo.GetByIdAsync(id);
        }

        public async Task<Cellar> GetByNameAsync(string name)
        {
            var queryable = await _genericCellarRepo.GetAllAsync();
            var cellar = await queryable.FirstOrDefaultAsync(x => x.Name == name);

            return cellar;
        }
        #endregion
    }
}
