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
    public class SaleRepository : IGenericRepository<Sale>
    {
        private readonly FerreteriaDbContext _context;
        public SaleRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(Sale obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            string detailIntoString = BuildSaleDetailString(obj.SaleDets);

            var insert = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_insert_sale @documentId={obj.DocumentId}, @customerId={obj.CustomerId}, @userId={obj.UserId}, @transStateId = {obj.TransStateId}, @saleOrderId={obj.SaleOrderId}, @noDoc={obj.NoDoc}, @noSerie={obj.Serie}, @credit={obj.Credit}, @credit_days={obj.CreditDays}, @date={obj.Date}, @dateTrans={obj.DateTrans}, @subtotal={obj.Subtotal}, @iva={obj.Iva}, @total={obj.Total}, @detail={detailIntoString};").ToListAsync();

            if (!string.IsNullOrEmpty(insert[0].ErrorMessage))
                throw new Exception(insert[0].ErrorMessage);

            return true;
        }
        public async Task<bool> UpdateAsync(int id, Sale obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));

            string detailIntoString = BuildSaleDetailString(obj.SaleDets);

            var update = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_update_sale @id={id},@customerId={obj.CustomerId}, @userId={obj.UserId}, @transStateId={obj.TransStateId}, @noDoc = {obj.NoDoc}, @noSerie = {obj.Serie}, @credit={obj.Credit}, @credit_days={obj.CreditDays}, @dateTrans={obj.DateTrans}, @subtotal={obj.Subtotal}, @iva={obj.Iva},@total={obj.Total}, @detail = {detailIntoString};").ToListAsync();

            if (!string.IsNullOrEmpty(update[0].ErrorMessage))
                throw new Exception(update[0].ErrorMessage);

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var delete = await _context.SPCRUDs.FromSqlInterpolated($"EXEC sp_delete_sale {id};").ToListAsync();

            if (!string.IsNullOrEmpty(delete[0].ErrorMessage))
                throw new Exception(delete[0].ErrorMessage);

            return true;
        }
        public async Task<Sale> GetByIdAsync(int id)
        {
            var sale = await _context.Sales.Include(x => x.Document)
                .Include(x => x.Customer)
                .Include(x => x.SaleDets)
                .FirstOrDefaultAsync(x => x.Id == id);
            return sale;
        }
        public async Task<IQueryable<Sale>> GetAllAsync()
        {
            IQueryable<Sale> queryable =  _context.Sales.Include(x => x.Document)
                                            .Include(x => x.Customer);
            return queryable;
        }

        #region metodos propios
        private string BuildSaleDetailString(IEnumerable<SaleDet> detail)
        {
            string detailIntoString = "";
            for (int i = 0; i < detail.Count(); i++)
            {
                detailIntoString += $"{detail.ElementAt(i).ProductId}, {detail.ElementAt(i).CellarId}," +
                                $"{detail.ElementAt(i).Price}, {detail.ElementAt(i).Units}," +
                                $"{detail.ElementAt(i).Discount}, {detail.ElementAt(i).SubTotal}";

                detailIntoString += ((detail.Count() > 1) && (i < detail.Count() - 1)) ? "|" : "";
            }

            return detailIntoString;
        }
        #endregion

    }
}
