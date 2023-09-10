using SalesProject.Application.DTO.buy_order.buy_order_detail;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.supplier.supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy_order.buy_order
{
    public class BuyOrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }

        public int Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public List<BuyOrderDetDTO> BuyOrderDets { get; set; }

        public DocumentDTO Document { get; set; }
        public SupplierDTO Supplier { get; set; }
        
        public DocumentDTO OutputDocument { get; set; }

    }
}
