using SalesProject.Application.DTO.buy.buy_detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy.buy
{
    public class BuyCreateDTO
    {
        public int DocumentId { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public int? BuyOrderId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public List<BuyDetCreateDTO> BuyDets { get; set; }
    }
}
