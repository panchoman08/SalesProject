﻿using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleReturnDet
{
    public int Id { get; set; }

    public int? SaleReturnId { get; set; }

    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public int? CellarId { get; set; }

    public decimal? Price { get; set; }

    public int? Units { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Cellar? Cellar { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale? Sale { get; set; }

    public virtual SaleReturn? SaleReturn { get; set; }
}
