using System;
using System.Collections.Generic;

namespace dbfirstScaffold.Models;

public partial class Acceso
{
    public long IdAcceso { get; set; }

    public string CodigoAcceso { get; set; } = null!;

    public string? DescripcionAcceso { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
