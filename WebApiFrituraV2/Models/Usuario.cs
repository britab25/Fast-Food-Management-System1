using System;
using System.Collections.Generic;

namespace WebApiFrituraV2.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string UsuarioLogin { get; set; } = null!;

    public string ClaveHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }
}
