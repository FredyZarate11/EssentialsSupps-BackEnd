using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string CodeProduct { get; set; } = null!;

    public string? NameProduct { get; set; }

    public string? Description { get; set; }

    public decimal? PriceProduct { get; set; }

    public int? Stock { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updateat { get; set; }

    public virtual ICollection<Productcategory> Productcategories { get; set; } = new List<Productcategory>();

    public virtual ICollection<Productmedium> Productmedia { get; set; } = new List<Productmedium>();

    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();

    public virtual ICollection<Shoppingcartitem> Shoppingcartitems { get; set; } = new List<Shoppingcartitem>();
}
