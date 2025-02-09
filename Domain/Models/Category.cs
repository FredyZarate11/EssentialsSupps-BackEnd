using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public string? Description { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Productcategory> Productcategories { get; set; } = new List<Productcategory>();
}
