using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Repository
{
    public class CellarTransferRepository : IGenericRepository<CellarTransfer>
    {
        private readonly FerreteriaDbContext _context;

        public CellarTransferRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(CellarTransfer obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            string stringDetail = BuildTransferDetailString(obj.CellarTransferDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_cellar_trans @documentId={obj.DocumentId},@userId={obj.UserId},@noTransfer={obj.NoTransfer}, @dateTrans={obj.DateTrans}, @date={obj.DateTrans},@observation={obj.Observation}, @detail={stringDetail};").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
            {
                throw new Exception(insert[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> UpdateAsync(int id, CellarTransfer obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            string stringDetail = BuildTransferDetailString(obj.CellarTransferDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_update_cellar_trans @id={id},@userId={obj.UserId},@noTransfer={obj.NoTransfer}, @dateTrans={obj.DateTrans},@date={obj.Date},@observation={obj.Observation}, @detail={stringDetail};").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
            {
                throw new Exception(update[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_cellar_trans @id={id}").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
            {
                throw new Exception(delete[0].ErrorMessage);
            }

            return true;
        }

        public async Task<IQueryable<CellarTransfer>> GetAllAsync()
        {
            IQueryable<CellarTransfer> queryable = _context.CellarTransfers.Include(x => x.CellarTransferDets);
            return queryable;
        }

        public async Task<CellarTransfer> GetByIdAsync(int id)
        {
            return await _context.CellarTransfers.Include(x => x.CellarTransferDets)
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        private string BuildTransferDetailString(ICollection<CellarTransferDet> detail)
        {
            string stringDetail = "";

            for (int i=0; i<detail.Count; i++)
            {
                stringDetail += $"{detail.ElementAt(i).ProductId}, {detail.ElementAt(i).CellarOriginId}," +
                    $"{detail.ElementAt(i).CellarDestinationId}, {detail.ElementAt(i).Units}";

                stringDetail += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return stringDetail;
        }

        
    }
}
