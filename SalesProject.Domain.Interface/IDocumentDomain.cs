using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IDocumentDomain 
    {
        #region async methods
        Task<bool> InsertAsync(Document obj);
        Task<bool> UpdateAsync(int id, Document obj);
        Task<bool> DeleteAsync(int id);
        Task<Document> GetByIdAsync(int id);
        Task<Document> GetByNameAsync(string name);
        Task<List<Document>> GetAllByDocumentTypeAsync(string name);
        Task<IEnumerable<Document>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<Document>> GetAllAsync();
        Task<IQueryable<Document>> GetAllWithPagingAsync();
        Task<bool> RegisterExists(Document obj);
        #endregion
    }
}
