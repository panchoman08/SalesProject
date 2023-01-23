using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Nit { get; set; } = null!;

    public string? Cui { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? CreditDays { get; set; }

    public decimal? CreditLimit { get; set; }

    public bool? Defaulter { get; set; }

    public int CategoryId { get; set; }

    public virtual CustomerCat Category { get; set; } = null!;

    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    public virtual ICollection<SaleReturn> SaleReturns { get; } = new List<SaleReturn>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
