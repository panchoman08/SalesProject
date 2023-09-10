using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CellarId { get; set; }

    public int? Units { get; set; }

    public virtual Cellar Cellar { get; set; }

    public virtual Product Product { get; set; }
}
