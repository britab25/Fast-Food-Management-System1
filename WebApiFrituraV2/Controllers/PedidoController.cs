using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TiendaFriturasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly string _connectionString;

        public PedidoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexionDB");
        }

        public class PedidoRequestDto
        {
            public int ClienteID { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }

        public class PedidoResponseDto
        {
            public int PedidoID { get; set; }
            public int ClienteID { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
            public DateTime FechaPedido { get; set; }
        }

        public class DetallePedidoDto
        {
            public int PedidoId { get; set; }
            public int ProductoId { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        // POST: api/Pedido/RegistrarPedido
        [HttpPost("RegistrarPedido")]
        public async Task<IActionResult> RegistrarPedido([FromBody] PedidoRequestDto pedido)
        {
            if (pedido == null)
                return BadRequest("Datos de pedido inválidos.");

            int nuevoPedidoId;

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_RegistrarPedido", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                    cmd.Parameters.AddWithValue("@Total", pedido.Total);
                    cmd.Parameters.AddWithValue("@Estado", pedido.Estado ?? "Pendiente");

                    var outputParam = new SqlParameter("@PedidoID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    nuevoPedidoId = (int)outputParam.Value;
                }

                var pedidoResponse = new PedidoResponseDto
                {
                    PedidoID = nuevoPedidoId,
                    ClienteID = pedido.ClienteID,
                    Total = pedido.Total,
                    Estado = pedido.Estado,
                    FechaPedido = DateTime.Now
                };

                return Ok(pedidoResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar pedido: {ex.Message}");
            }
        }

        // POST: api/Pedido/RegistrarDetalle
        [HttpPost("RegistrarDetalle")]
        public async Task<IActionResult> RegistrarDetalle([FromBody] DetallePedidoDto detalle)
        {
            if (detalle == null || detalle.PedidoId <= 0 || detalle.ProductoId <= 0 || detalle.Cantidad <= 0 || detalle.PrecioUnitario <= 0)
            {
                return BadRequest("Datos del detalle inválidos.");
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_RegistrarDetallePedido", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PedidoID", detalle.PedidoId);
                    cmd.Parameters.AddWithValue("@ProductoID", detalle.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

                return Ok("Detalle del pedido registrado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar detalle del pedido: {ex.Message}");
            }
        }

        // GET: api/Pedido/{id}
        [HttpGet("ConsultarPedidoPorPedido/{id:int}")]
        public async Task<IActionResult> ObtenerPedido(int id)
        {
            try
            {
                PedidoResponseDto pedido = null;

                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT PedidoID, ClienteID, FechaPedido, Total, Estado FROM Pedidos WHERE PedidoID = @PedidoID", conn))
                {
                    cmd.Parameters.AddWithValue("@PedidoID", id);

                    await conn.OpenAsync();

                    using var reader = await cmd.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        pedido = new PedidoResponseDto
                        {
                            PedidoID = reader.GetInt32(0),
                            ClienteID = reader.GetInt32(1),
                            FechaPedido = reader.GetDateTime(2),
                            Total = reader.GetDecimal(3),
                            Estado = reader.GetString(4)
                        };
                    }
                }

                if (pedido == null)
                    return NotFound($"Pedido con ID {id} no encontrado.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener pedido: {ex.Message}");
            }
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            try
            {
                var pedidos = new List<PedidoResponseDto>();

                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT PedidoID, ClienteID, FechaPedido, Total, Estado FROM Pedidos ORDER BY FechaPedido DESC", conn))
                {
                    await conn.OpenAsync();

                    using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        pedidos.Add(new PedidoResponseDto
                        {
                            PedidoID = reader.GetInt32(0),
                            ClienteID = reader.GetInt32(1),
                            FechaPedido = reader.GetDateTime(2),
                            Total = reader.GetDecimal(3),
                            Estado = reader.GetString(4)
                        });
                    }
                }

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar pedidos: {ex.Message}");
            }
        }

        // PUT: api/Pedido/{id}
        [HttpPut("ActualizarPedidoPorPedido/{id:int}")]
        public async Task<IActionResult> ActualizarPedido(int id, [FromBody] PedidoRequestDto pedido)
        {
            if (pedido == null)
                return BadRequest("Datos inválidos.");

            try
            {
                int filasAfectadas;

                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("UPDATE Pedidos SET ClienteID = @ClienteID, Total = @Total, Estado = @Estado WHERE PedidoID = @PedidoID", conn))
                {
                    cmd.Parameters.AddWithValue("@PedidoID", id);
                    cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                    cmd.Parameters.AddWithValue("@Total", pedido.Total);
                    cmd.Parameters.AddWithValue("@Estado", pedido.Estado ?? "Pendiente");

                    await conn.OpenAsync();
                    filasAfectadas = await cmd.ExecuteNonQueryAsync();
                }

                if (filasAfectadas == 0)
                    return NotFound($"Pedido con ID {id} no encontrado.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar pedido: {ex.Message}");
            }
        }

        // DELETE: api/Pedido/{id}
        [HttpDelete("EliminarPedidoPorPedido/{id:int}")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            try
            {
                int filasAfectadas;

                using (var conn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("DELETE FROM Pedidos WHERE PedidoID = @PedidoID", conn))
                {
                    cmd.Parameters.AddWithValue("@PedidoID", id);

                    await conn.OpenAsync();
                    filasAfectadas = await cmd.ExecuteNonQueryAsync();
                }

                if (filasAfectadas == 0)
                    return NotFound($"Pedido con ID {id} no encontrado.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar pedido: {ex.Message}");
            }
        }
    }
}
