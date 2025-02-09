using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Shoppingcartitem
{
    public int Shoppingcartid { get; set; }

    public int Productid { get; set; }

    public int? Amount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Shoppingcart Shoppingcart { get; set; } = null!;
}
