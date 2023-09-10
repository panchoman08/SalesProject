using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.product.measure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.product.product
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public int StatusId { get; set; }
        public int CategoryId { get; set; }
        public int MeasureId { get; set; }
        public int BrandId { get; set; }
    }
}
