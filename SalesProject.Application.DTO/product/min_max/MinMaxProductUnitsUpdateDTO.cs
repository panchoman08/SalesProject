using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.product.min_max
{
    public class MinMaxProductUnitsUpdateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CellarId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Minimum { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Maximum { get; set; }
    }
}
