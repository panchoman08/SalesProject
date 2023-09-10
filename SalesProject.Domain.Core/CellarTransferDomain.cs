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
    public class CellarTransferDomain : ICellarTransferDomain
    {
        private readonly IGenericRepository<CellarTransfer> _genericCellarTransRepo;
        private readonly IGenericRepository<Document> _genericDocumentRepo;
        public CellarTransferDomain(IGenericRepository<CellarTransfer> genericRepository, 
            IGenericRepository<Document> genericDocumentRepo)
        {
            _genericCellarTransRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(CellarTransfer obj)
        {
            if (!await IsACellarTransferDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a cellar transfer type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a cellar transfer with the same noTransfer for this document.");
            }

            return await _genericCellarTransRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, CellarTransfer obj)
        {
            return await _genericCellarTransRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericCellarTransRepo.DeleteAsync(id);
        }
        public async Task<CellarTransfer> GetByIdAsync(int id)
        {
            return await _genericCellarTransRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<CellarTransfer>> GetAllAsync()
        {
            return await _genericCellarTransRepo.GetAllAsync();
        }
        public async Task<IQueryable<CellarTransfer>> GetAllWithPagingAsync()
        {
            return await _genericCellarTransRepo.GetAllAsync();
        }
        public async Task<bool> IsACellarTransferDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return (document != null) ? document.DocumentType.Description == "cellar transfer" :
                false;
        }
        public async Task<bool> RegisterExists(CellarTransfer obj)
        {
            var queryable = await _genericCellarTransRepo.GetAllAsync();
            return queryable.Any(x => x.NoTransfer == obj.NoTransfer);
        }
        
        #endregion
    }
}
