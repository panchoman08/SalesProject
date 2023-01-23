using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class UserSy
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RolId { get; set; }

    public virtual ICollection<BuyOrder> BuyOrders { get; } = new List<BuyOrder>();

    public virtual ICollection<BuyReturn> BuyReturns { get; } = new List<BuyReturn>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual ICollection<CellarTransfer> CellarTransfers { get; } = new List<CellarTransfer>();

    public virtual RolUser? Rol { get; set; }

    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    public virtual ICollection<SaleReturn> SaleReturns { get; } = new List<SaleReturn>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
