using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Salesstatus
{
    public int IdStatus { get; set; }

    public string? NameStatus { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Paymenthistory> Paymenthistories { get; set; } = new List<Paymenthistory>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
