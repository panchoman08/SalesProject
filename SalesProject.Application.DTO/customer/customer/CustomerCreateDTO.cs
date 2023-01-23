using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.customer.customer
{
    public class CustomerCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Nit { get; set; }
        public string Cui { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool Defaulter { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }
}
