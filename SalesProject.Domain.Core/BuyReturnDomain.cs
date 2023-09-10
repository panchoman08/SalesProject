using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Core
{
    public class BuyReturnDomain : IBuyReturnDomain
    {
        private readonly IGenericRepository<BuyReturn> _genericBuyReturnRepo;
        private readonly IGenericRepository<Document> _genericDocumentRepo;

        public BuyReturnDomain(IGenericRepository<BuyReturn> genericRepository, 
            IGenericRepository<Document> genericDocumentRepo)
        {
            _genericBuyReturnRepo = genericRepository;
            _genericDocumentRepo = genericDocumentRepo;
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyReturn obj)
        {
            if (!await IsABuyReturnDocument(obj.DocumentId))
            {
                throw new Exception("The input document is not for a buy return type document.");
            }

            if (string.IsNullOrEmpty(obj.Observation))
            {
                throw new Exception("The observation field must not be empty.");
            }

            if (await RegisterExists(obj))
            {
                throw new Exception("There is already a buy return created with the same noDoc and Serie for this document.");
            }

            return await _genericBuyReturnRepo.InsertAsync(obj);
        }
        public async Task<bool> UpdateAsync(int id, BuyReturn obj)
        {
            return await _genericBuyReturnRepo.UpdateAsync(id, obj);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _genericBuyReturnRepo.DeleteAsync(id);
        }
        public async Task<BuyReturn> GetByIdAsync(int id)
        {
            return await _genericBuyReturnRepo.GetByIdAsync(id);
        }
        public async Task<IQueryable<BuyReturn>> GetAllAsync()
        {
            return await _genericBuyReturnRepo.GetAllAsync();
        }
        public async Task<IQueryable<BuyReturn>> GetAllWithPagingAsync()
        {
            return await _genericBuyReturnRepo.GetAllAsync();
        }
        public async Task<bool> IsABuyReturnDocument(int id)
        {
            var document = await _genericDocumentRepo.GetByIdAsync(id);
            return document.DocumentType.Description == "buy return";
        }
        public async Task<bool> RegisterExists(BuyReturn obj)
        {
            var queryable = await _genericBuyReturnRepo.GetAllAsync();
            return await queryable.AnyAsync(x => x.NoDoc == obj.NoDoc && x.Serie == obj.Serie
                                            && x.DocumentId == obj.DocumentId);
        }

        
        #endregion
    }
}
