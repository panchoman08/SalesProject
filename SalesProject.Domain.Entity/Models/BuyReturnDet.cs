using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyReturnDet
{
    public int Id { get; set; }

    public int? BuyReturnId { get; set; }

    public int? BuyId { get; set; }

    public int? ProductId { get; set; }

    public string Name { get; set; }

    public int? CellarId { get; set; }

    public decimal? Price { get; set; }

    public int? Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Subtotal { get; set; }

    public string Sku { get; set; }

    public virtual Buy Buy { get; set; }

    public virtual BuyReturn BuyReturn { get; set; }

    public virtual Cellar Cellar { get; set; }

    public virtual Product Product { get; set; }
}
