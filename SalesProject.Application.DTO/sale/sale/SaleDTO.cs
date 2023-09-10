﻿using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.sale.sale_detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.sale.sale
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public int? SaleOrderId { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public bool Credit { get; set; }
        public int CreditDays { get; set; }
        public DateTime DateTrans { get; set; }
        public DateTime Date { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public List<SaleDetDTO> SaleDets { get; set; }

        public DocumentDTO Document { get; set; }
        public CustomerDTO Customer { get; set; }

    }
}