using SalesProject.Application.DTO.sale_return.sale_return_det;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.sale_return.sale_return
{
    public class SaleReturnCreateDTO
    {
        public int DocumentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public DateTime DateTrans { get; set; }
        public string Observation { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public List<SaleReturnDetCreateDTO> SaleReturnDets { get; set; }
    }
}
