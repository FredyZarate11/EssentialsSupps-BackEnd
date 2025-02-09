using System;
using System.Collections.Generic;

namespace EssentialsSupps_Backend.Domain.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public string? Description { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
