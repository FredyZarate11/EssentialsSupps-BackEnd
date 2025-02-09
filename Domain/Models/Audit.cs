using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Audit
{
    public int IdAudit { get; set; }

    public int Userid { get; set; }

    public string? Action { get; set; }

    public int Tableid { get; set; }

    public string? Oldvalue { get; set; }

    public string? Newvalue { get; set; }

    public DateTime? Createdat { get; set; }
}
