using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.customer.customer
{
    public class CustomerUpdateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Nit { get; set; }
        public string? Cui { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public decimal CreditLimit { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CreditDays { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public bool Defaulter { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }
}
