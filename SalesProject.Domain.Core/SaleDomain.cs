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
    public class SaleDomain : ISaleDomain
    {
        private readonly IGenericRepository<Sale> _genericSaleRepo;
        private readonly IGenericRepository<Document> _genericDocumentRepo;
        private readonly IGenericRepository<SaleReturn> _genericSaleReturnRepo;

        public SaleDomain(IGenericRepository<Sale> genericSaleRepository,
            IGenericRepository<Document> genericDocumentRepo,
            IGenericRepository<SaleReturn> genericSaleReturnRepo)
        {
            _genericSaleRepo = genericSaleRepository;
            _genericDocumentRepo = genericDocumentRepo;
            _genericSaleReturnRepo = genericSaleReturnRepo;
        }

        public async Task<bool> InsertAsync(Sale obj)
        {
            if (!await IsASaleDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a sale type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a sale with the same NoDoc and Serie for this document.");
            }

            return await _genericSaleRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, Sale obj)
        {
            return await _genericSaleRepo.UpdateAsync(id, obj); 
        }
        public async Task<bool> DeleteAsync(int id)
        {
            if (await HasSaleReturnGenerated(id))
            {
                throw new Exception("This sale has a sale return generated. Please first delete it and try again.");
            }

            return await _genericSaleRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<Sale>> GetAllAsync()
        {
            return await _genericSaleRepo.GetAllAsync();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _genericSaleRepo.GetByIdAsync(id);
        }
        public async Task<bool> IsASaleDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "sale";
        }

        public async Task<bool> RegisterExists(Sale obj)
        {
            var queryable = await _genericSaleRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie &&
                                            x.DocumentId == obj.DocumentId);
        }

        public async Task<bool> HasSaleReturnGenerated(int id)
        {
            var queryable = await _genericSaleReturnRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.SaleReturnDets.Any(x => x.SaleId == id));
        }

        public Task<IQueryable<Sale>> GetAllWithPagingAsync()
        {
            return _genericSaleRepo.GetAllAsync();
        }
    }
}
