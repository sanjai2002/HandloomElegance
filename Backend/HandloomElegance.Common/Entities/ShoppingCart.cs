using System;
using System.Collections.Generic;

namespace HandloomElegance.Common.Entities;
public partial class ShoppingCart
{
    public Guid CartId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
