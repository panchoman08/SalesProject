using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Measure
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
