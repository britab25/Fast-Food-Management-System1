using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiFrituraV2.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiFrituraV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly TiendaFriturasDbContext _context;

        public FacturaController(TiendaFriturasDbContext context)
        {
            _context = context; // Asignamos el contexto de la base de datos
        }

        public class FacturaDto
        {

            public int PedidoID { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }


        [HttpPost("RegistrarFactura")]
        public async Task<IActionResult> RegistrarFactura([FromBody] FacturaDto factura)
        {
            if (factura == null)
            {
                return BadRequest("Factura no puede ser nula.");
            }

            try
            {
                // Parámetros del DTO
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@PedidoID", factura.PedidoID),
                new SqlParameter("@Total", factura.Total),
                new SqlParameter("@Estado", factura.Estado)
                };

                // Ejecutamos el procedimiento almacenado y obtenemos el FacturaID generado
                var facturaIdParam = new SqlParameter("@FacturaID", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                parameters = parameters.Append(facturaIdParam).ToArray();

                // Ejecutamos el SP usando el DbContext
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_RegistrarFactura @PedidoID, @Total, @Estado, @FacturaID OUT", parameters);

                // Obtenemos el FacturaID del parámetro de salida
                var facturaId = (int)facturaIdParam.Value;

                // Si el FacturaID es 0, hubo un problema con la inserción
                if (facturaId == 0)
                {
                    return StatusCode(500, "La factura no se pudo registrar correctamente.");
                }

                // Devolvemos la respuesta con el FacturaID generado
                return Ok(new
                {
                    FacturaID = facturaId,
                    PedidoId = factura.PedidoID,  // PedidoId que fue enviado
                    Estado = factura.Estado,      // Estado que se envió en el DTO
                    Total = factura.Total,        // Total que se envió en el DTO
                    FechaFactura = DateTime.Now   // Fecha generada por GETDATE() en el SP
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        [HttpGet("ConsultarFacturaPorFactura/{facturaId}")]
        public async Task<IActionResult> ConsultarFacturaPorFactura(int facturaId)
        {
            var factura = await _context.Facturas
                .Where(f => f.FacturaId == facturaId)
                .Select(f => new
                {
                    f.FacturaId,
                    f.PedidoId,
                    f.FechaFactura,
                    f.Total,
                    f.Estado,
                    NombreCliente = f.Pedido.Cliente.Nombre,  // Aquí traemos el nombre del cliente desde Pedido -> Cliente
                    DetalleProductos = f.Pedido.DetallePedidos.Select(dp => new
                    {
                        Producto = dp.Producto.Nombre,
                        dp.Cantidad,
                        PrecioUnitario = dp.PrecioUnitario,
                        Subtotal = dp.Cantidad * dp.PrecioUnitario   // calculamos subtotal si no existe en la BD
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (factura == null) return NotFound();

            return Ok(factura);
        }





        [HttpGet("ConsultarFacturaPorPedido/{pedidoId}")]
        public async Task<IActionResult> ConsultarFacturaPorPedido(int pedidoId)
        {
            var parameters = new SqlParameter("@PedidoID", pedidoId);

            // Ejecutar la consulta SQL y proyectar los resultados usando AsEnumerable()
            var factura = _context.Facturas
                .FromSqlRaw("EXEC ConsultarFacturaPorPedidoID @PedidoID", parameters)
                .AsEnumerable()  // Proyección en memoria (debe ser sincronizada)
                .Select(f => new
                {
                    f.FacturaId,
                    f.PedidoId,  // Accede correctamente a PedidoId
                    f.FechaFactura,
                    f.Total,
                    f.Estado
                })
                .FirstOrDefault();  // Realizamos la proyección en memoria y obtenemos el primer resultado

            if (factura == null)
            {
                return NotFound();  // Si no se encuentra la factura
            }

            return Ok(factura);  // Retorna la factura encontrada
        }




        public class ActualizarEstadoDto
        {
            public string Estado { get; set; }
        }

        [HttpPut("ActualizarEstadoFactura/{facturaId}")]
        public async Task<IActionResult> ActualizarEstadoFactura(int facturaId, [FromBody] ActualizarEstadoDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Estado))
                return BadRequest("Estado inválido.");

            var parameters = new SqlParameter[]
            {
        new SqlParameter("@FacturaID", facturaId),
        new SqlParameter("@NuevoEstado", dto.Estado)
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC ActualizarEstadoFactura @FacturaID, @NuevoEstado", parameters);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar estado: {ex.Message}");
            }
        }


        [HttpDelete("EliminarFactura/{facturaId}")]
        public async Task<IActionResult> EliminarFactura(int facturaId)
        {
            var parameters = new SqlParameter("@FacturaID", facturaId);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC EliminarFactura @FacturaID", parameters);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("ListarFacturas")]
        public async Task<IActionResult> ObtenerFacturas()
        {
            var facturas = await _context.Facturas
                .Select(f => new
                {
                    f.FacturaId,   // Usamos el alias correcto "f"
                    f.PedidoId,    // Usamos el alias correcto "f"
                    f.FechaFactura,
                    f.Total,
                    f.Estado
                })
                .ToListAsync();

            return Ok(facturas);
        }
    }
}
