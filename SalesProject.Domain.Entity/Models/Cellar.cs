using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Cellar
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public virtual ICollection<BuyOrderDet> BuyOrderDets { get; } = new List<BuyOrderDet>();

    public virtual ICollection<BuyReturnDet> BuyReturnDets { get; } = new List<BuyReturnDet>();

    public virtual ICollection<CellarTransferDet> CellarTransferDetCellarDestinations { get; } = new List<CellarTransferDet>();

    public virtual ICollection<CellarTransferDet> CellarTransferDetCellarOrigins { get; } = new List<CellarTransferDet>();

    public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();

    public virtual ICollection<MinMaxProd> MinMaxProds { get; } = new List<MinMaxProd>();

    public virtual ICollection<SaleDet> SaleDets { get; } = new List<SaleDet>();

    public virtual ICollection<SaleOrderDet> SaleOrderDets { get; } = new List<SaleOrderDet>();

    public virtual ICollection<SaleReturnDet> SaleReturnDets { get; } = new List<SaleReturnDet>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();
}
