using SalesProject.Domain.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Interface
{
    public interface IDocumentTypeDomain
    {
        #region async methods
        Task<bool> InsertAsync(DocumentType obj);
        Task<bool> UpdateAsync(int id, DocumentType obj);
        Task<bool> DeleteAsync(int id);
        Task<DocumentType> GetByIdAsync(int id);
        Task<DocumentType> GetByNameAsync(string name);
        Task<IEnumerable<DocumentType>> GetAllTthatContainsNameAsync(string name);
        Task<IQueryable<DocumentType>> GetAllAsync();
        #endregion
    }
}
