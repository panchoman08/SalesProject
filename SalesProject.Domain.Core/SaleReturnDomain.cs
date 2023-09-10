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
    public class SaleReturnDomain : ISaleReturnDomain
    {
        public readonly IGenericRepository<SaleReturn> _genericSaleReturnRepo;
        public readonly IGenericRepository<Document> _genericDocumentRepo;

        public SaleReturnDomain(IGenericRepository<SaleReturn> genericRepository, 
            IGenericRepository<Document> genericDocumentRepo)
        {
            _genericSaleReturnRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }
        public async Task<bool> InsertAsync(SaleReturn obj)
        {
            if (! await IsASaleReturnDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a sale return type document.");
            }
            if (string.IsNullOrEmpty(obj.Observation))
            {
                throw new Exception("The observation field must not be empty.");
            }
            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a sale return created with the same noDoc and Serie for this document.");
            }

            return await _genericSaleReturnRepo.InsertAsync(obj);
        }
        public Task<bool> UpdateAsync(int id, SaleReturn obj)
        {
            return _genericSaleReturnRepo.UpdateAsync(id, obj);
        }
        public Task<bool> DeleteAsync(int id)
        {
            return _genericSaleReturnRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<SaleReturn>> GetAllAsync()
        {
            var queryable = await _genericSaleReturnRepo.GetAllAsync();
            return queryable;
        }

        public Task<SaleReturn> GetByIdAsync(int id)
        {
            return _genericSaleReturnRepo.GetByIdAsync(id);
        }

        public async Task<bool> IsASaleReturnDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "sale return";
        }

        public async Task<bool> RegisterExists(SaleReturn obj)
        {
            var queryable = await _genericSaleReturnRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie
                            && x.DocumentId == obj.DocumentId);
        }

        public async Task<IQueryable<SaleReturn>> GetAllWithPagingAsync()
        {
            return await _genericSaleReturnRepo.GetAllAsync();
        }
    }
}
