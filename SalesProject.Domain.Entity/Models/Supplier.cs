using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Nit { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; } = new List<BuyOrder>();

    public virtual ICollection<BuyReturn> BuyReturns { get; } = new List<BuyReturn>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual SupplierCat Category { get; set; } = null!;
}
