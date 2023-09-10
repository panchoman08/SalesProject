using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.sale_return.sale_return_det
{
    public class SaleReturnDetUpdateDTO
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
    }
}
