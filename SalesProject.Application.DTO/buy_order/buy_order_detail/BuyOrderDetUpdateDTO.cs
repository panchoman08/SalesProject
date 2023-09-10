﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.buy_order.buy_order_detail
{
    public class BuyOrderDetUpdateDTO
    {
        public int BuyOrderId { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
    }
}