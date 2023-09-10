using SalesProject.Application.DTO.cellar_transfer.cellar_transfer_det;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.DTO.cellar_transfer.cellar_transfer
{
    public class CellarTransferUpdateDTO
    {
        public int UserId { get; set; }
        public int TransStateId { get; set; }
        public string NoTransfer { get; set; }
        public DateTime DateTrans { get; set; }
        public string Observation { get; set; }
        public List<CellarTransferDetUpdateDTO> CellarTransferDets { get; set; }
    }
}
