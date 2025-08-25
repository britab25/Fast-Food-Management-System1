using System;
using System.Collections.Generic;

namespace WebApiFrituraV2.Models;

public partial class Proveedore
{
    public int CodigoProveedor { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
