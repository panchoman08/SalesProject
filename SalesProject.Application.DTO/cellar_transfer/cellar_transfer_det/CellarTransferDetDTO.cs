using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.cellar_transfer.cellar_transfer_det
{
    public class CellarTransferDetDTO
    {
        public int Id { get; set; }
        public int CellarTransId { get; set; }
        public int ProductId { get; set; }
        public int CellarOriginId { get; set; }
        public int CellarDestinationId { get; set; }
        public int Units { get; set; }

    }
}
