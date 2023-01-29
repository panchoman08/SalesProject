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
    public class DocumentTypeDomain : IDocumentTypeDomain
    {
        private readonly IGenericRepository<DocumentType> _genericDocumentTypeRepo;

        public DocumentTypeDomain(IGenericRepository<DocumentType> genericRepository)
        {
            _genericDocumentTypeRepo= genericRepository;
        }

        public async Task<bool> InsertAsync(DocumentType obj)
        {
            if (await GetByNameAsync(obj.Description) != null)
            {
                throw new Exception("There is already a document type created with the same name.");
            }

            return await _genericDocumentTypeRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, DocumentType obj)
        {
            return await _genericDocumentTypeRepo.UpdateAsync(id, obj);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _genericDocumentTypeRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<DocumentType>> GetAllAsync()
        {
            return await _genericDocumentTypeRepo.GetAllAsync();
        }

        public async Task<IEnumerable<DocumentType>> GetAllTthatContainsNameAsync(string name)
        {
            var customerQueryable = await _genericDocumentTypeRepo.GetAllAsync();
            var documentsType = customerQueryable.Where(x => x.Description.Contains(name)).ToList();

            return documentsType;
        }

        public async Task<DocumentType> GetByIdAsync(int id)
        {
            return await _genericDocumentTypeRepo.GetByIdAsync(id);
        }

        public async Task<DocumentType> GetByNameAsync(string name)
        {
            var customerQueryable = await _genericDocumentTypeRepo.GetAllAsync();
            var documentsType = customerQueryable.FirstOrDefault(x => x.Description.Equals(name));

            return documentsType;
        }

    }
}
