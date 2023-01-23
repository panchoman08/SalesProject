using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Document
{
    public int Id { get; set; }

    public int DocumentTypeId { get; set; }

    public string Description { get; set; } = null!;

    public string? Serie { get; set; }

    public int? InternalCorrelative { get; set; }

    public virtual ICollection<BuyOrder> BuyOrderDocuments { get; } = new List<BuyOrder>();

    public virtual ICollection<BuyOrder> BuyOrderOutputDocuments { get; } = new List<BuyOrder>();

    public virtual ICollection<BuyReturn> BuyReturns { get; } = new List<BuyReturn>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<SaleOrder> SaleOrderDocuments { get; } = new List<SaleOrder>();

    public virtual ICollection<SaleOrder> SaleOrderOutputDocuments { get; } = new List<SaleOrder>();

    public virtual ICollection<SaleReturn> SaleReturns { get; } = new List<SaleReturn>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
