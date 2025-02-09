using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Paymentmethod
{
    public int IdPayment { get; set; }

    public string? NamePayment { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
