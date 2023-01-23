using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CellarTransfer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string NoTransfer { get; set; } = null!;

    public int CellarOriginId { get; set; }

    public int CellarDestinationId { get; set; }

    public DateTime? DateTrans { get; set; }

    public DateTime? Date { get; set; }

    public virtual Cellar CellarDestination { get; set; } = null!;

    public virtual Cellar CellarOrigin { get; set; } = null!;

    public virtual ICollection<CellarTransferDet> CellarTransferDets { get; } = new List<CellarTransferDet>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();

    public virtual UserSy User { get; set; } = null!;
}
