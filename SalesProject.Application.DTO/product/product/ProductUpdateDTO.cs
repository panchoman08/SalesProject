using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.product.measure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.product.product
{
    public class ProductUpdateDTO
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public int StatusId { get; set; }
        public int Category { get; set; }
        public int Measure { get; set; }
        public int Brand { get; set; }
    }
}
