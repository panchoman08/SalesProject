using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class BuyOrderRepository : IGenericRepository<BuyOrder>
    {
        private readonly FerreteriaDbContext _context;
        public BuyOrderRepository(FerreteriaDbContext context) 
        {
            _context = new FerreteriaDbContext();
        }

        #region async methods
        public async Task<bool> InsertAsync(BuyOrder obj)
        {
            obj.DateTrans = DateTime.Parse(obj.DateTrans.ToString("yyyy-MM-dd"));
            obj.Date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.BuyOrders.AddAsync(obj);
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
        public async Task<bool> UpdateAsync(int id, BuyOrder obj)
        {
            using (var transaction =  _context.Database.BeginTransaction())
            {
                try
                {
                    // removing the current buy order detail...
                    var buyOrderDet = await _context.BuyOrderDets.Where(x => x.BuyOrderId == id).ToListAsync();

                    _context.RemoveRange(buyOrderDet);
                    await _context.SaveChangesAsync();

                    // modifying the buy order cab
                    var buyOrder = await _context.BuyOrders.FirstOrDefaultAsync(x => x.Id == id);

                    buyOrder.NoDoc = obj.NoDoc;
                    buyOrder.SupplierId = obj.SupplierId;
                    buyOrder.TransStateId = obj.TransStateId;
                    buyOrder.OutputDocumentId = obj.OutputDocumentId;

                    buyOrder.DateTrans = obj.DateTrans;
                    buyOrder.Credit = obj.Credit;
                    buyOrder.CreditDays = obj.CreditDays;
                    buyOrder.Iva = obj.Iva;
                    buyOrder.Subtotal = obj.Subtotal;
                    buyOrder.Total = obj.Total;

                    // adding the new buy order detail
                    buyOrder.BuyOrderDets = obj.BuyOrderDets;

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
                    var buyOrderDetail = await _context.BuyOrderDets.Where(x => x.BuyOrderId == id).ToListAsync();

                    _context.BuyOrderDets.RemoveRange(buyOrderDetail);
                    await _context.SaveChangesAsync();

                    var buyOrder = await _context.BuyOrders.FirstOrDefaultAsync(x => x.Id == id);

                    _context.BuyOrders.Remove(buyOrder);
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
        public async Task<BuyOrder> GetByIdAsync(int id)
        {
            var buyOrder = await _context.BuyOrders.Include(x => x.Document)
                                                .Include(x => x.Supplier)
                                                .Include(x => x.User)
                                                .Include(x => x.TransState)
                                                .Include(x => x.OutputDocument)
                                                .Include(x => x.BuyOrderDets)
                                                .FirstOrDefaultAsync(x => x.Id == id);

            return buyOrder;
        }

        public async Task<IQueryable<BuyOrder>> GetAllAsync()
        {
            IQueryable<BuyOrder> queryable = _context.BuyOrders.Include(x => x.Document)
                                                .Include(x => x.Supplier)
                                                .Include(x => x.User)
                                                .Include(x => x.TransState)
                                                .Include(x => x.OutputDocument);
            return queryable;
        }
        #endregion

    }
}
