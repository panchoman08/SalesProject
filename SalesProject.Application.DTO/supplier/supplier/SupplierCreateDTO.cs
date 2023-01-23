using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.supplier.supplier
{
    public class SupplierCreateDTO
    {
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
    }
}
