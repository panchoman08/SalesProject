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
    public class BuyRepisotory : IGenericRepository<Buy>
    {
        private readonly FerreteriaDbContext _context;

        public BuyRepisotory(FerreteriaDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(Buy obj)
        {

            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            //var buyDetail = BuildBuyDetailString(obj.BuyDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_buy @documentId={obj.DocumentId}, @supplierId = {obj.SupplierId}, @userId = {obj.UserId}, @buyOrderId={obj.BuyOrderId}, @transStateId = {obj.TransStateId}, @noDoc = {obj.NoDoc}, @noSerie = {obj.Serie}, @credit = {obj.Credit}, @credit_days = {obj.CreditDays}, @date = {obj.Date}, @dateTrans = {obj.DateTrans}, @subtotal = {obj.Subtotal}, @iva = {obj.Iva}, @total = {obj.Total}, @detail = {obj.Total}").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);
            
            return true;
        }
        public async Task<bool> UpdateAsync(int id, Buy obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            //var buyDetail = BuildBuyDetailString(obj.BuyDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_update_buy @id = {id}, @supplierId = {obj.SupplierId}, @userId = {obj.UserId}, @transStateId = {obj.TransStateId}, @buyOrderId = {obj.BuyOrderId}, @noDoc = {obj.NoDoc}, @noSerie = {obj.Serie}, @credit = {obj.Credit}, @credit_days = {obj.CreditDays},  @dateTrans = {obj.DateTrans}, @subtotal = {obj.Subtotal}, @iva = {obj.Iva}, @total = {obj.Total}, @detail = {obj.Total}").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
                throw new Exception(update[0].ErrorMessage);

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_buy {id};").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
                throw new Exception(delete[0].ErrorMessage);

            return true;
        }
        public async Task<Buy> GetByIdAsync(int id)
        {
            var buy = await _context.Buys.Include(x => x.Supplier)
                                    .Include(x => x.Document)
                                    //.Include(x => x.BuyDets)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return buy;
        }
        public async Task<IQueryable<Buy>> GetAllAsync()
        {
            IQueryable<Buy> queryable = _context.Buys.Include(x => x.Supplier)
                                    .Include(x => x.Document);//.Include(x => x.BuyDets);
            return queryable;
        }
        #endregion

        #region metodos propios
        private string BuildBuyDetailString(IEnumerable<BuyDet> detail)
        {
            string detailIntoString = "";
            for (int i=0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).ProductId},{detail.ElementAt(i).Price}," +
                                $"{detail.ElementAt(i).Units}, {detail.ElementAt(i).Discount}," +
                                $"{detail.ElementAt(i).Subtotal},{detail.ElementAt(i).CellarId}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion
    }
}
