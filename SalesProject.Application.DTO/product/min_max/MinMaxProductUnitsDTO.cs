using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.product.min_max
{
    public class MinMaxProductUnitsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

    }
}
