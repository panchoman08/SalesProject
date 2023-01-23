using SalesProject.Application.DTO.supplier.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.supplier.supplier
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public SupplierCatDTO Category { get; set; }
    }
}
