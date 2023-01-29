using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Repository
{
    public class DocumentTypeRepository : IGenericRepository<DocumentType>
    {
        private readonly FerreteriaDbContext _context;
        public DocumentTypeRepository()
        {
            _context = new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(DocumentType obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, DocumentType obj)
        {
            var documentType = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);

            documentType.Description = obj.Description;

            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var documentType = await _context.DocumentTypes.SingleAsync(x => x.Id == id);
            var delete = _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<DocumentType> GetByIdAsync(int id)
        {
            var documentType = await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
            return documentType;
        }
        public async Task<IQueryable<DocumentType>> GetAllAsync()
        {
            IQueryable<DocumentType> queryable = _context.DocumentTypes;
            return queryable;
        }
        #endregion
    }
}
