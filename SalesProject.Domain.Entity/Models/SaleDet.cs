using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleDet
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int CellarId { get; set; }

    public decimal Price { get; set; }

    public int Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? SubTotal { get; set; }

    public string Name { get; set; }

    public string Sku { get; set; }

    public virtual Cellar Cellar { get; set; }

    public virtual Product Product { get; set; }

    public virtual Sale Sale { get; set; }
}
