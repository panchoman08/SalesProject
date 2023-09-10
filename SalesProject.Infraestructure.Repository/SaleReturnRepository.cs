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
    public class SaleReturnRepository : IGenericRepository<SaleReturn>
    {
        private readonly FerreteriaDbContext _context;
        public SaleReturnRepository(FerreteriaDbContext context) 
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(SaleReturn obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            var detailIntoString = BuildBuyDetailString(obj.SaleReturnDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_sale_return @document_id={obj.DocumentId}, @customer_id={obj.CustomerId}, @user_id={obj.UserId}, @transStateId={obj.TransStateId}, @noDoc={obj.NoDoc}, @serie={obj.Serie}, @credit={obj.Credit}, @date_trans={obj.DateTrans}, @date = {obj.Date}, @observation = {obj.Observation}, @subtotal={obj.Subtotal}, @iva = {obj.Iva}, @total = {obj.Total}, @detail = {detailIntoString};").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
            {
                throw new Exception(insert[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> UpdateAsync(int id, SaleReturn obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            var detailIntoString = BuildBuyDetailString(obj.SaleReturnDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_update_sale_return @id={id},@customerId={obj.CustomerId},@trans_state_id={obj.TransStateId},@noDoc={obj.NoDoc},@serie={obj.Serie},@credit={obj.Credit},@date_trans={obj.DateTrans},@observation={obj.Observation},@subtotal={obj.Subtotal},@iva={obj.Iva},@total={obj.Total},@detail={detailIntoString};").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
            {
                throw new Exception(update[0].ErrorMessage);
            }

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_sale_return @id={id};").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
            {
                throw new Exception(delete[0].ErrorMessage);
            }

            return true;
        }
        public async Task<SaleReturn> GetByIdAsync(int id)
        {
            var saleReturn = await _context.SaleReturns.FirstOrDefaultAsync(x => x.Id == id);
            return saleReturn;
        }
        public async Task<IQueryable<SaleReturn>> GetAllAsync()
        {
            IQueryable<SaleReturn> queryable = _context.SaleReturns;
            return queryable;
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<SaleReturnDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).SaleId}, {detail.ElementAt(i).ProductId}, {detail.ElementAt(i).CellarId}," +
                                $"{detail.ElementAt(i).Price}, {detail.ElementAt(i).Units}, {detail.ElementAt(i).Discount}," +
                                $"{detail.ElementAt(i).Subtotal}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion
    }
}
