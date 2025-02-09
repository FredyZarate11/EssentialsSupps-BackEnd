using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Dominio.Models;

public partial class Sale
{
    public int IdSale { get; set; }

    public int Userid { get; set; }

    public DateTime? Saledate { get; set; }

    public decimal? Totalamount { get; set; }

    public int? Status { get; set; }

    public int? Paymentmethod { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Paymenthistory> Paymenthistories { get; set; } = new List<Paymenthistory>();

    public virtual Paymentmethod? PaymentmethodNavigation { get; set; }

    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();

    public virtual Salesstatus? StatusNavigation { get; set; }

    public virtual Person User { get; set; } = null!;
}
