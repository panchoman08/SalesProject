using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class CustomerCat
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
