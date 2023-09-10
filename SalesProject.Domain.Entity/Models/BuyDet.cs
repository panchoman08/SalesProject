using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyDet
{
    public int Id { get; set; }

    public int BuyId { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; }

    public string Name { get; set; }

    public int? CellarId { get; set; }

    public decimal? Price { get; set; }

    public int? Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Buy Buy { get; set; }
}
