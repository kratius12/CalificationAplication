using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Ranking
{
    public int Id { get; set; }

    public int? IdPer { get; set; }

    public int? Calificacion { get; set; }

    public virtual Personaje? IdPerNavigation { get; set; }
}
