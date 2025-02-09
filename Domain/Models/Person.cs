using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public string EmailPerson { get; set; } = null!;

    public string? Passwordhash { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public DateTime? Laslogin { get; set; }

    public bool? Isactive { get; set; }

    public int Roleid { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updateat { get; set; }

    public virtual ICollection<Personmedium> Personmedia { get; set; } = new List<Personmedium>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Shoppingcart> Shoppingcarts { get; set; } = new List<Shoppingcart>();
}
