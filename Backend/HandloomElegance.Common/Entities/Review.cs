using System;
using System.Collections.Generic;

namespace HandloomElegance.Common.Entities;
public partial class Review
{
    public Guid ReviewId { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? UserId { get; set; }

    public sbyte Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
