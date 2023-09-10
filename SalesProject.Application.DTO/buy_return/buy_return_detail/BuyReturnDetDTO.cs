using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy_return.buy_return_detail
{
    public class BuyReturnDetDTO
    {
        public int Id { get; set; }
        public int BuyReturnId { get; set; }
        public int BuyId { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; } 
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
    }
}
