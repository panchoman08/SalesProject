using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyOrderDet
{
    public int Id { get; set; }

    public int BuyOrderId { get; set; }

    public int ProductId { get; set; }

    public int? CellarId { get; set; }

    public decimal? Price { get; set; }

    public int? Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual BuyOrder BuyOrder { get; set; } = null!;

    public virtual Cellar? Cellar { get; set; }

    public virtual Product Product { get; set; } = null!;
}
