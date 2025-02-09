using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Dominio.Models;

public partial class Personmedium
{
    public int IdPersonmedia { get; set; }

    public string UrlMedia { get; set; } = null!;

    public int Personid { get; set; }

    public bool? Isprimary { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Person Person { get; set; } = null!;
}
