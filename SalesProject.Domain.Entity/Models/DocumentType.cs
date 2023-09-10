using System;
using System.Collections.Generic;

namespace SalesProject.Domain.Entity.Models;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Document> Documents { get; } = new List<Document>();
}
