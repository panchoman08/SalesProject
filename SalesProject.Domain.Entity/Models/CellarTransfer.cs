using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CellarTransfer
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int UserId { get; set; }

    public string NoTransfer { get; set; }

    public DateTime DateTrans { get; set; }

    public DateTime? Date { get; set; }

    public string Observation { get; set; }

    public virtual ICollection<CellarTransferDet> CellarTransferDets { get; } = new List<CellarTransferDet>();

    public virtual Document Document { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();

    public virtual UserSy User { get; set; }
}
