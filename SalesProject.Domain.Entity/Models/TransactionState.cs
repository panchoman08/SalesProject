using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class TransactionState
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; } = new List<BuyOrder>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
