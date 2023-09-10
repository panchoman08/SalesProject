using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleOrderDet
{
    public int Id { get; set; }

    public int SaleOrderId { get; set; }

    public int? CellarId { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual Cellar Cellar { get; set; }

    public virtual Product Product { get; set; }

    public virtual SaleOrder SaleOrder { get; set; }
}
