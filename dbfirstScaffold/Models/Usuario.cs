using System;
using System.Collections.Generic;

namespace dbfirstScaffold.Models;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string DniUsuario { get; set; } = null!;

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? TlfUsuario { get; set; }

    public string? EmailUsuario { get; set; }

    public string? ClaveUsuario { get; set; }

    public bool? EstaBloqueadoUsuario { get; set; }

    public TimeOnly? FchFinBloqueo { get; set; }

    public long? IdAcceso { get; set; }

    public DateTime? FchAltaUsuario { get; set; }

    public DateTime? FchBajaUsuario { get; set; }

    public virtual Acceso? IdAccesoNavigation { get; set; }
}
