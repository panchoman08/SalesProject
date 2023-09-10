using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Domain.Core
{
    public class BuyOrderDomain : IBuyOrderDomain
    {
        private readonly IGenericRepository<BuyOrder> _genericBuyOrderRepo;
        private readonly IGenericRepository<Document> _genericDocumentRepo;
        private readonly IGenericRepository<Buy> _genericBuyRepo;
        public BuyOrderDomain(IGenericRepository<BuyOrder> genericBuyOrderRepo, 
            IGenericRepository<Document> genericDocumentRepo,
            IGenericRepository<Buy> genericBuyRepo) 
        {
            _genericBuyOrderRepo = genericBuyOrderRepo;
            _genericDocumentRepo = genericDocumentRepo;
            _genericBuyRepo = genericBuyRepo;
        }
        public async Task<bool> InsertAsync(BuyOrder obj)
        {
            if (!await IsABuyOrderDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a buy order type document.");
            }

            if (!await IsABuyDocument(obj.OutputDocumentId))
            {
                throw new Exception("The output document is not for a buy type document.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a buy order register with the same NoDoc and Serie for this document.");
            }

            return await _genericBuyOrderRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(int id, BuyOrder obj)
        {
            return await _genericBuyOrderRepo.UpdateAsync(id, obj);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (await HasBuyGenerated(id))
            {
                throw new Exception("There is a buy generated from this buy order. Please delete it first and try again.");
            }

            return await _genericBuyOrderRepo.DeleteAsync(id);
        }

        public async Task<IQueryable<BuyOrder>> GetAllAsync()
        {
            return await _genericBuyOrderRepo.GetAllAsync();
        }

        public async Task<BuyOrder> GetByIdAsync(int id)
        {
            return await _genericBuyOrderRepo.GetByIdAsync(id);
        }
        public Task<IQueryable<BuyOrder>> GetAllWithPagingAsync()
        {
            return _genericBuyOrderRepo.GetAllAsync();
        }

        public async Task<bool> GenerateBuyBasedOnBuyOrder(Buy obj)
        {
            if (await HasBuyGenerated(obj.BuyOrderId ?? 0))
            {
                throw new Exception("There is already a buy created with this buy order id.");
            }

            return await _genericBuyRepo.InsertAsync(obj);
        }
        public async Task<bool> HasBuyGenerated(int id)
        {
            var queryable = await _genericBuyRepo.GetAllAsync();
            return queryable.Any(x => x.BuyOrderId == id);
        }

        public async Task<bool> IsABuyDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "buy";
        }

        public async Task<bool> IsABuyOrderDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "buy order";
        }

        public async Task<bool> RegisterExists(BuyOrder obj)
        {
            var queryable = await _genericBuyOrderRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie && x.DocumentId == obj.DocumentId);
        }

        
    }
}
