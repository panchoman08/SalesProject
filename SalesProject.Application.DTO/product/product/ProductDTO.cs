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
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public int StatusId { get; set; }
        public ProductCatDTO Category { get; set; }
        public ProductMeasureDTO Measure { get; set; }
        public ProductBrandDTO Brand { get; set; }
    }
}
