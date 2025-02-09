using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Dominio.Models;

public partial class Productcategory
{
    public int IdProductcategory { get; set; }

    public int Productid { get; set; }

    public int Categoryid { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
