using System;
using System.Collections.Generic;

namespace WebApiFrituraV2.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Nombre { get; set; } = null!; // obligatorio
    public string? Telefono { get; set; }       // opcional
    public string? Email { get; set; }          // opcional
    public string? Direccion { get; set; }      // opcional
    public DateTime FechaRegistro { get; set; } // obligatorio
    public string? Apellido { get; set; }       // opcional
    public string? TipoDocumento { get; set; }  // opcional
    public string? NumeroDocumento { get; set; }// opcional

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}

