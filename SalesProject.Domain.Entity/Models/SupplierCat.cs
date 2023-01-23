using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SupplierCat
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
