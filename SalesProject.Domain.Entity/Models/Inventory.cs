using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CellarId { get; set; }

    public int? BuyId { get; set; }

    public int? SaleId { get; set; }

    public int? CellarTransId { get; set; }

    public int? Units { get; set; }

    public virtual Buy? Buy { get; set; }

    public virtual Cellar Cellar { get; set; } = null!;

    public virtual CellarTransfer? CellarTrans { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale? Sale { get; set; }
}
