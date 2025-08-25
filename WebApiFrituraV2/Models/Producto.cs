using System;
using System.Collections.Generic;

namespace WebApiFrituraV2.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Categoria { get; set; }

    public int Stock { get; set; }

    public string? Descripcion { get; set; }

    public int? CodigoInventario { get; set; }

    public int? CodigoProveedor { get; set; }

    public virtual Proveedore? CodigoProveedorNavigation { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}
