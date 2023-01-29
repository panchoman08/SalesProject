using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Repository
{
    public class DocumentRepository : IGenericRepository<Document>
    {
        private readonly FerreteriaDbContext _context;

        public DocumentRepository()
        {
            _context = new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(Document obj)
        {
            var insert = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();

            return insert != null;
        }
        public async Task<bool> UpdateAsync(int id, Document obj)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            document.Description = obj.Description;
            document.Serie = obj.Serie;


            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var document = await _context.Documents.SingleAsync(x => x.Id == id);
            var delete = _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return delete != null;
        }
        public async Task<Document> GetByIdAsync(int id)
        {
            var documentType = await _context.Documents.Include(x => x.DocumentType).FirstOrDefaultAsync(x => x.Id == id);
            return documentType;
        }
        public async Task<IQueryable<Document>> GetAllAsync()
        {
            IQueryable<Document> queryable = _context.Documents.Include(x => x.DocumentType);
            return queryable;
        }
        #endregion
    }
}
