using System;
using System.Collections.Generic;

namespace WebApiFrituraV2.Models;

public class Factura
{
    public int FacturaId { get; set; }
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }  // Relación con Pedido
    public DateTime FechaFactura { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }

}