using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Productmedium
{
    public int IdProductmedia { get; set; }

    public string UrlMedia { get; set; } = null!;

    public int Productid { get; set; }

    public bool? Isprimary { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Product Product { get; set; } = null!;
}
