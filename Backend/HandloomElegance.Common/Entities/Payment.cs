using System;
using System.Collections.Generic;

namespace HandloomElegance.Common.Entities;

public partial class Payment
{
    public Guid PaymentId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
