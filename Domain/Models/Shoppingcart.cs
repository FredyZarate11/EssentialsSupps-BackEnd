using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Shoppingcart
{
    public int IdShoppingcart { get; set; }

    public int Userid { get; set; }

    public DateTime? Updateat { get; set; }

    public virtual ICollection<Shoppingcartitem> Shoppingcartitems { get; set; } = new List<Shoppingcartitem>();

    public virtual Person User { get; set; } = null!;
}
