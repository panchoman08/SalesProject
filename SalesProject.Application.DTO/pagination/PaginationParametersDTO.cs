using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SalesProject.Application.DTO.pagination
{
    public class PaginationParametersDTO
    {
        const int maxPageSize = 50;
        [Required]
        public int PageNumber { get; set; }

        private int _pageSize;

        [Required]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
