using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class ProductSalePrice
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CatSalePriceId { get; set; }

    public decimal? Price { get; set; }

    public virtual CategorySalePrice CatSalePrice { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
