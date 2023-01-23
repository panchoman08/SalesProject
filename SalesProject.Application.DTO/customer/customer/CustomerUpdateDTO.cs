using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.customer.customer
{
    public class CustomerUpdateDTO
    {
        public string Nit { get; set; }
        public string Cui { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool Defaulter { get; set; }
        public int CategoryId { get; set; }
    }
}
