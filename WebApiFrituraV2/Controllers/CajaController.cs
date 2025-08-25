using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiFrituraV2.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CajaController : ControllerBase
{
    private readonly TiendaFriturasDbContext _context;

    public CajaController(TiendaFriturasDbContext context)
    {
        _context = context;
    }

    public class AperturaCajaDto
    {
        public int UsuarioId { get; set; }
        public decimal MontoInicial { get; set; }
        public string Observaciones { get; set; }
    }

    public class CierreCajaDto
    {
        public int UsuarioId { get; set; }
        public decimal MontoFinal { get; set; }
        public string Observaciones { get; set; }
    }

    [HttpPost("AperturaCaja")]
    public async Task<IActionResult> AperturaCaja([FromBody] AperturaCajaDto apertura)
    {
        if (apertura == null)
            return BadRequest("Datos de apertura nulos.");

        if (apertura.UsuarioId <= 0)
            return BadRequest("UsuarioId inválido.");

        if (apertura.MontoInicial <= 0)
            return BadRequest("Monto inicial debe ser mayor que cero.");

        try
        {
            var nuevoRegistro = new HistorialCaja
            {
                UsuarioID = apertura.UsuarioId,
                FechaHora = DateTime.Now,
                TipoEvento = "Apertura",
                MontoInicial = apertura.MontoInicial,
                MontoFinal = null,
                Observaciones = apertura.Observaciones
            };

            _context.HistorialCaja.Add(nuevoRegistro);
            await _context.SaveChangesAsync();

            return Ok("Apertura registrada correctamente.");
        }
        catch (Exception ex)
        {
            var innerMessage = ex.InnerException?.Message ?? "";
            return StatusCode(500, $"Error en AperturaCaja: {ex.Message} {innerMessage}");
        }
    }

    [HttpPost("CierreCaja")]
    public async Task<IActionResult> CierreCaja([FromBody] CierreCajaDto cierre)
    {
        if (cierre == null)
            return BadRequest("Datos de cierre nulos.");

        if (cierre.UsuarioId <= 0)
            return BadRequest("UsuarioId inválido.");

        if (cierre.MontoFinal <= 0)
            return BadRequest("Monto final debe ser mayor que cero.");

        try
        {
            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_RegistrarCierreCaja @UsuarioID, @MontoFinal, @Observaciones",
                new SqlParameter("@UsuarioID", cierre.UsuarioId),
                new SqlParameter("@MontoFinal", cierre.MontoFinal),
                new SqlParameter("@Observaciones", (object)cierre.Observaciones ?? DBNull.Value)
            );

            return Ok(new { mensaje = "Cierre registrado correctamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error en CierreCaja: {ex.Message}");
        }
    }

    [HttpGet("HistorialCaja")]
    public async Task<IActionResult> GetHistorialCaja([FromQuery] DateTime fecha)
    {
        if (fecha == default)
            return BadRequest("Fecha inválida.");

        try
        {
            var lista = await _context.HistorialCaja
                .Where(h => h.FechaHora.Date == fecha.Date)
                .OrderBy(h => h.FechaHora)
                .ToListAsync();

            return Ok(lista);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error en GetHistorialCaja: {ex.Message}");
        }
    }

    [HttpGet("ReporteVentasDia")]
    public async Task<IActionResult> ReporteVentasDia([FromQuery] DateTime fecha)
    {
        if (fecha == default)
            return BadRequest("Fecha inválida.");

        try
        {
            var startDate = fecha.Date;
            var endDate = startDate.AddDays(1);

            var resultado = await _context.Facturas
                .Where(f => f.FechaFactura >= startDate && f.FechaFactura < endDate &&
                            (f.Estado.ToLower() == "completado" || f.Estado.ToLower() == "finalizado"))
                .Select(f => new
                {
                    f.FacturaId,
                    f.PedidoId,
                    f.FechaFactura,
                    f.Total,
                    f.Estado
                })
                .ToListAsync();

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error en ReporteVentasDia: {ex.Message}");
        }
    }
}
