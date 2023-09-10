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
    public class SaleOrderRepository : IGenericRepository<SaleOrder>
    {
        private readonly FerreteriaDbContext _context;
        public SaleOrderRepository(FerreteriaDbContext context)
        {
            _context = context;
        }

        #region async methods
        public async Task<bool> InsertAsync(SaleOrder obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaleOrders.AddAsync(obj);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }

            }
            return true;
        }
        public async Task<bool> UpdateAsync(int id, SaleOrder obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // removing the current buy order detail...
                    var saleOrderDet = await _context.SaleOrderDets.Where(x => x.SaleOrderId == id).ToListAsync();

                    _context.RemoveRange(saleOrderDet);
                    await _context.SaveChangesAsync();

                    // modifying the buy order cab
                    var saleOrder = await _context.SaleOrders.FirstOrDefaultAsync(x => x.Id == id);

                    saleOrder.CustomerId = obj.CustomerId;
                    saleOrder.TransStateId = obj.TransStateId;
                    saleOrder.OutputDocumentId = obj.OutputDocumentId;

                    saleOrder.NoDoc = obj.NoDoc;
                    saleOrder.Serie = obj.Serie;
                    saleOrder.Credit = obj.Credit;
                    saleOrder.CreditDays = obj.CreditDays;
                    saleOrder.DateTrans = obj.DateTrans;
                    saleOrder.Iva = obj.Iva;
                    saleOrder.Subtotal = obj.Subtotal;
                    saleOrder.Total = obj.Total;

                    // adding the new buy order detail
                    saleOrder.SaleOrderDets = obj.SaleOrderDets;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var saleOrderDetail = await _context.SaleOrderDets.Where(x => x.SaleOrderId == id).ToListAsync();

                    _context.SaleOrderDets.RemoveRange(saleOrderDetail);
                    await _context.SaveChangesAsync();

                    var saleOrder = await _context.SaleOrders.FirstOrDefaultAsync(x => x.Id == id);

                    _context.SaleOrders.Remove(saleOrder);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
            return true;
        }
        public async Task<SaleOrder> GetByIdAsync(int id)
        {
            var saleOrder = await _context.SaleOrders.Include(x => x.Document)
                                                .Include(x => x.Document)
                                                .Include(x => x.User)
                                                .Include(x => x.TransState)
                                                .Include(x => x.OutputDocument)
                                                .Include(x => x.SaleOrderDets)
                                                .FirstOrDefaultAsync(x => x.Id == id);
            return saleOrder;
        }
        public async Task<IQueryable<SaleOrder>> GetAllAsync()
        {
            IQueryable<SaleOrder> queryable = _context.SaleOrders.Include(x => x.Document)
                                                .Include(x => x.Customer)
                                                .Include(x => x.User)
                                                .Include(x => x.TransState)
                                                .Include(x => x.OutputDocument)
                                                .Include(x => x.SaleOrderDets);
            return queryable;
        }
        #endregion
    }
}
