using SalesProject.Application.DTO.buy_return.buy_return_detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy_return.buy_return
{
    public class BuyReturnDTO
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public DateTime DateTrans { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public List<BuyReturnDetDTO> BuyReturnDets { get; set; }
    }
}
