using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CellarTransferDet
{
    public int Id { get; set; }

    public int CellarTransId { get; set; }

    public int ProductId { get; set; }

    public int CellarOriginId { get; set; }

    public int CellarDestinationId { get; set; }

    public int Units { get; set; }

    public virtual Cellar CellarDestination { get; set; }

    public virtual Cellar CellarOrigin { get; set; }

    public virtual CellarTransfer CellarTrans { get; set; }

    public virtual Product Product { get; set; }
}
