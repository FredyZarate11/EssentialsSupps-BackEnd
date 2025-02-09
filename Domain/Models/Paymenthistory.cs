using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Dominio.Models;

public partial class Paymenthistory
{
    public int IdPaymenthistory { get; set; }

    public int Saleid { get; set; }

    public string Transactionid { get; set; } = null!;

    public decimal? Amount { get; set; }

    public int? Status { get; set; }

    public string? Result { get; set; }

    public DateTime? Paymentdate { get; set; }

    public virtual Sale Sale { get; set; } = null!;

    public virtual Salesstatus? StatusNavigation { get; set; }
}
