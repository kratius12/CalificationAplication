using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Personaje
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Genero { get; set; }

    public string? Especie { get; set; }

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();
}
