using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleReturn
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int CustomerId { get; set; }

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

    public virtual Customer Customer { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual ICollection<SaleReturnDet> SaleReturnDets { get; } = new List<SaleReturnDet>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();

    public virtual UserSy User { get; set; } = null!;
}
