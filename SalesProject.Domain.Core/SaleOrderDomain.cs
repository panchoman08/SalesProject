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
    public class SaleOrderDomain : ISaleOrderDomain
    {
        public readonly IGenericRepository<SaleOrder> _genericSaleOrderRepo;
        public readonly IGenericRepository<Document> _genericDocumentRepo;
        public readonly IGenericRepository<Sale> _genericSaleRepo;

        public SaleOrderDomain(IGenericRepository<SaleOrder> genericSaleOrderRepo,
                                IGenericRepository<Document> genericDocumentRepo,
                                IGenericRepository<Sale> genericSaleRepo
                                )
        {
            _genericSaleOrderRepo = genericSaleOrderRepo;
            _genericDocumentRepo = genericDocumentRepo;
            _genericSaleRepo = genericSaleRepo;

        }

        #region async methods
        public async Task<bool> InsertAsync(SaleOrder obj)
        {
            if (! await IsASaleOrderDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a sale order type document.");
            }

            if (!await IsASaleDocument(obj.OutputDocumentId))
            {
                throw new Exception("The output document is not for a sale type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a sale order register with the same NoDoc and Serie for this document.");
            }

            return await _genericSaleOrderRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, SaleOrder obj)
        {
            return await _genericSaleOrderRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            if (await HasSaleGenerated(id))
            {
                throw new Exception("There is a buy generated from this buy order. Please delete it first and try again.");
            }
            return await _genericSaleOrderRepo.DeleteAsync(id);
        }
        public async Task<SaleOrder> GetByIdAsync(int id)
        {
            return await _genericSaleOrderRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<SaleOrder>> GetAllAsync()
        {
            return await _genericSaleOrderRepo.GetAllAsync();
        }

        public async Task<IQueryable<SaleOrder>> GetAllWithPagingAsync()
        {
            return await _genericSaleOrderRepo.GetAllAsync();
        }

        #region validations
        public async Task<bool> RegisterExists(SaleOrder obj)
        {
            var queryable = await _genericSaleOrderRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie 
                                        && x.DocumentId == obj.DocumentId);
        }

        public async Task<bool> IsASaleOrderDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "sale order";
        }
        public async Task<bool> IsASaleDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "sale";
        }

        public async Task<bool> HasSaleGenerated(int id)
        {
            var queryable = await _genericSaleRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.SaleOrderId == id);
        }

        public async Task<bool> GenerateSaleBasedOnSaleOrder(Sale obj)
        {
            if (await HasSaleGenerated(obj.SaleOrderId ?? 0))
            {
                throw new Exception("There is already a sale created with this sale order id.");
            }

            return await _genericSaleRepo.InsertAsync(obj);
        }

        
        #endregion

        #endregion
    }
}
