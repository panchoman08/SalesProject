using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class SaleOrder
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int CustomerId { get; set; }

    public int UserId { get; set; }

    public int TransStateId { get; set; }

    public int OutputDocumentId { get; set; }

    public string? NoDoc { get; set; }

    public string? Serie { get; set; }

    public bool? Credit { get; set; }

    public int? CreditDays { get; set; }

    public DateTime? DateTrans { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Total { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Document Document { get; set; } = null!;

    public virtual Document OutputDocument { get; set; } = null!;

    public virtual ICollection<SaleOrderDet> SaleOrderDets { get; } = new List<SaleOrderDet>();

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();

    public virtual TransactionState TransState { get; set; } = null!;

    public virtual UserSy User { get; set; } = null!;
}
