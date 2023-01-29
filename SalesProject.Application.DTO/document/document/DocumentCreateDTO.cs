using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.document.document
{
    public class DocumentCreateDTO
    {
        public int DocumentTypeId { get; set; }
        public string Description { get; set; }
        public string Serie { get; set; }
        public int InternalCorrelative { get; set; }
    }
}
