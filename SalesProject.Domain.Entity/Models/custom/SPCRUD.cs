using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Entity.Models.custom
{
    [Keyless]
    public class SPCRUD
    {
        public string ErrorMessage { get; set; }
    }
}
