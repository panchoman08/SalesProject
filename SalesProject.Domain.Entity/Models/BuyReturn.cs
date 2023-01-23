using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyReturn
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int SupplierId { get; set; }

    public int UserId { get; set; }

    public int TransStateId { get; set; }

    public string NoDoc { get; set; } = null!;

    public string? Serie { get; set; }

    public bool? Credit { get; set; }

    public DateTime? DateTrans { get; set; }

    public DateTime? Date { get; set; }

    public string? Observation { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Iva { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<BuyReturnDet> BuyReturnDets { get; } = new List<BuyReturnDet>();

    public virtual Document Document { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();

    public virtual UserSy User { get; set; } = null!;
}
