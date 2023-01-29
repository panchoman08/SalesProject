using SalesProject.Application.DTO.document.documentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.document.document
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        public string Serie { get; set; }
        public int InternalCorrelative { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
    }
}
