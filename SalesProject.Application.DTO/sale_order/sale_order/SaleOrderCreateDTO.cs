using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.sale_order.sale_order_detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.sale_order.sale_order
{
    public class SaleOrderCreateDTO
    {
        public int DocumentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public int OutputDocumentId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public List<SaleOrderDetCreateDTO> SaleOrderDets { get; set; }
    }
}
