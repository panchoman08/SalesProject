using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.product.brand
{
    public class ProductBrandCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }
}
