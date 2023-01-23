using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class TransactionDetail
{
    public int Id { get; set; }

    public int? BuyId { get; set; }

    public int? SaleId { get; set; }

    public int? BuyReturnId { get; set; }

    public int? SaleReturnId { get; set; }

    public int? CellarTransferId { get; set; }

    public int? ProductId { get; set; }

    public int? CellarId { get; set; }

    public int? Units { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Value { get; set; }

    public int? NoDoc { get; set; }

    public virtual Buy? Buy { get; set; }

    public virtual BuyReturn? BuyReturn { get; set; }

    public virtual Cellar? Cellar { get; set; }

    public virtual CellarTransfer? CellarTransfer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale? Sale { get; set; }

    public virtual SaleReturn? SaleReturn { get; set; }
}
