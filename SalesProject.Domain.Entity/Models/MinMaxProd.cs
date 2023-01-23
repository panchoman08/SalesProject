using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class MinMaxProd
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CellarId { get; set; }

    public int Minimum { get; set; }

    public int Maximum { get; set; }

    public virtual Cellar Cellar { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
