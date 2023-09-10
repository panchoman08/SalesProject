using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Core
{
    public class DocumentDomain : IDocumentDomain
    {
        private readonly IGenericRepository<Document> _genericDocumentRepo;

        public DocumentDomain(IGenericRepository<Document> genericRepository)
        {
            _genericDocumentRepo= genericRepository;
        }

        public async Task<bool> InsertAsync(Document obj)
        {
            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a document created with the same document type, description and serie.");
            }

            return await _genericDocumentRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, Document obj)
        {
            return await _genericDocumentRepo.UpdateAsync(id, obj);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _genericDocumentRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<Document>> GetAllAsync()
        {
            return await _genericDocumentRepo.GetAllAsync();
        }

        public async Task<IQueryable<Document>> GetAllWithPagingAsync()
        {
            return await _genericDocumentRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Document>> GetAllTthatContainsNameAsync(string name)
        {
            var customerQueryable = await _genericDocumentRepo.GetAllAsync();
            var documents = customerQueryable.Where(x => x.Description.Contains(name)).ToList();

            return documents;
        }

        public async Task<Document> GetByIdAsync(int id)
        {
            return await _genericDocumentRepo.GetByIdAsync(id);
        }

        public async Task<Document> GetByNameAsync(string name)
        {
            var customerQueryable = await _genericDocumentRepo.GetAllAsync();
            var documents = customerQueryable.FirstOrDefault(x => x.Description.Equals(name));

            return documents;
        }

        public async Task<bool> RegisterExists(Document obj)
        {
            var queryable = await _genericDocumentRepo.GetAllAsync();
  
            var exist = await queryable.AnyAsync(x => x.DocumentTypeId == obj.DocumentTypeId &&
                                                x.Description == obj.Description && x.Serie == obj.Serie);
            return exist;
        }

        public async Task<List<Document>> GetAllByDocumentTypeAsync(string name)
        {
            var queryable = await _genericDocumentRepo.GetAllAsync();
            return await queryable.Where(x => x.DocumentType.Description == name).ToListAsync();
        }
    }
}
