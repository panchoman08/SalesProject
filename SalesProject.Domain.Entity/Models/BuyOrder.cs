using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class BuyOrder
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public int SupplierId { get; set; }

    public int UserId { get; set; }

    public int TransStateId { get; set; }

    public int OutputDocumentId { get; set; }

    public string NoDoc { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public bool? Credit { get; set; }

    public int? CreditDays { get; set; }

    public DateTime? DateTrans { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? Iva { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<BuyOrderDet> BuyOrderDets { get; } = new List<BuyOrderDet>();

    public virtual ICollection<Buy> Buys { get; } = new List<Buy>();

    public virtual Document Document { get; set; } = null!;

    public virtual Document OutputDocument { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual TransactionState TransState { get; set; } = null!;

    public virtual UserSy User { get; set; } = null!;
}
