using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Dominio.Models;

public partial class Saledetail
{
    public int IdSaledetail { get; set; }

    public int Saleid { get; set; }

    public int Productid { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
