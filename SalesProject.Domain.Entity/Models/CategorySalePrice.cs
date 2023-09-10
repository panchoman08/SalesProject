using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CategorySalePrice
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<ProductSalePrice> ProductSalePrices { get; } = new List<ProductSalePrice>();
}
