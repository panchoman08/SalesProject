using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class BuyReturnRepository : IGenericRepository<BuyReturn>
    {
        private readonly FerreteriaDbContext _context;

        public BuyReturnRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyReturn obj)
        {

            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            var returnSaleIntoString = BuildBuyDetailString(obj.BuyReturnDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_buy_return @document_id={obj.DocumentId}, @supplierId={obj.SupplierId}, @userId={obj.UserId}, @transStateId={obj.TransStateId}, @noDoc={obj.NoDoc}, @serie={obj.Serie}, @credit={obj.Credit}, @dateTrans={obj.DateTrans},@date={obj.Date}, @observation={obj.Observation}, @subtotal={obj.Subtotal}, @iva={obj.Iva}, @total={obj.Total}, @detail={returnSaleIntoString}").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);

            return true;
        }
        public async Task<bool> UpdateAsync(int id, BuyReturn obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            var buyReturnDet = BuildBuyDetailString(obj.BuyReturnDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"exec sp_update_buy_return @id={id}, @supplierId={obj.SupplierId}, @trans_state_id={obj.TransStateId}, @noDoc={obj.NoDoc}, @serie={obj.Serie}, @credit={obj.Credit}, @date_trans={obj.DateTrans}, @observation={obj.Observation}, @subtotal={obj.Subtotal}, @iva={obj.Iva}, @total={obj.Total}, @detail={buyReturnDet};").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
                throw new Exception(update[0].ErrorMessage);

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_buy_return @id={id};").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
                throw new Exception(delete[0].ErrorMessage);

            return true;
        }
        public async Task<BuyReturn> GetByIdAsync(int id)
        {
            var buy = await _context.BuyReturns.Include(x => x.Supplier)
                                    .Include(x => x.Document)
                                    .Include(x => x.BuyReturnDets)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return buy;
        }
        public async Task<IQueryable<BuyReturn>> GetAllAsync()
        {
            IQueryable<BuyReturn> queryable = _context.BuyReturns.Include(x => x.Supplier)
                                    .Include(x => x.Document).Include(x => x.BuyReturnDets);
            return queryable;
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<BuyReturnDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).BuyId}, {detail.ElementAt(i).ProductId}, {detail.ElementAt(i).CellarId}," +
                                $"{detail.ElementAt(i).Price}, {detail.ElementAt(i).Units}, {detail.ElementAt(i).Discount}," +
                                $"{detail.ElementAt(i).Subtotal}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion
    }
}
