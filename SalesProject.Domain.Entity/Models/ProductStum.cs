using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class ProductStum
{
    public byte Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
