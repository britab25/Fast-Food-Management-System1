using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiFrituraV2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiFrituraV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly TiendaFriturasDbContext _context;

        public ClienteController(TiendaFriturasDbContext context)
        {
            _context = context;
        }

        // POST: api/Cliente/RegistrarCliente
        [HttpPost("RegistrarCliente")]
        public async Task<IActionResult> RegistrarCliente([FromBody] ClienteDto cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return BadRequest("El nombre es obligatorio.");

            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Nombre", cliente.Nombre),
                    new SqlParameter("@Apellido", (object?)cliente.Apellido ?? DBNull.Value),
                    new SqlParameter("@TipoDocumento", (object?)cliente.TipoDocumento ?? DBNull.Value),
                    new SqlParameter("@NumeroDocumento", (object?)cliente.NumeroDocumento ?? DBNull.Value),
                    new SqlParameter("@Telefono", (object?)cliente.Telefono ?? DBNull.Value),
                    new SqlParameter("@Email", (object?)cliente.Email ?? DBNull.Value),
                    new SqlParameter("@Direccion", (object?)cliente.Direccion ?? DBNull.Value),
                    new SqlParameter("@FechaRegistro", DateTime.Now)
                };

                // Ejecutar el SP
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_RegistrarCliente @Nombre, @Apellido, @TipoDocumento, @NumeroDocumento, @Telefono, @Email, @Direccion, @FechaRegistro",
                    parameters);

                // Buscar el cliente recién creado (por nombre y fecha más reciente)
                var clienteInsertado = await _context.Clientes
                    .Where(c => c.Nombre == cliente.Nombre)
                    .OrderByDescending(c => c.FechaRegistro)
                    .FirstOrDefaultAsync();

                if (clienteInsertado == null)
                    return StatusCode(500, "Cliente registrado, pero no se pudo recuperar su ID.");

                return Ok(new { mensaje = "Cliente registrado exitosamente", clienteInsertado.ClienteId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar cliente: {ex.Message}");
            }
        }

        public class ClienteDto
        {
            public string Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? TipoDocumento { get; set; }
            public string? NumeroDocumento { get; set; }
            public string? Telefono { get; set; }
            public string? Email { get; set; }
            public string? Direccion { get; set; }
        }

        // GET: api/Cliente/ListarClientes
        [HttpGet("ListarClientes")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var clientes = await _context.Clientes
                .Select(c => new
                {
                    c.ClienteId,
                    c.Nombre,
                    c.Apellido,
                    c.TipoDocumento,
                    c.NumeroDocumento,
                    c.Telefono,
                    c.Email,
                    c.Direccion,
                    c.FechaRegistro
                })
                .ToListAsync();

            return Ok(clientes);
        }

        // GET: api/Cliente/{numeroDocumento}
        [HttpGet("{numeroDocumento}")]
        public async Task<ActionResult<Cliente>> Get(string numeroDocumento)
        {
            try
            {
                var clientes = await _context.Clientes
                    .FromSqlRaw("EXEC ConsultarClientePorNumeroDocumento @NumeroDocumento",
                        new SqlParameter("@NumeroDocumento", numeroDocumento))
                    .ToListAsync();

                var cliente = clientes.FirstOrDefault();

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        public class ClienteUpdateDto
        {
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Telefono { get; set; }
            public string? Email { get; set; }
            public string? Direccion { get; set; }
        }

        // PUT: api/Cliente/{numeroDocumento}
        [HttpPut("{numeroDocumento}")]
        public async Task<IActionResult> Put(string numeroDocumento, [FromBody] ClienteUpdateDto clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("El cliente no puede ser nulo.");

            try
            {
                var clienteExistente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.NumeroDocumento == numeroDocumento);

                if (clienteExistente == null)
                    return NotFound();

                if (!string.IsNullOrEmpty(clienteDto.Nombre))
                    clienteExistente.Nombre = clienteDto.Nombre;

                if (!string.IsNullOrEmpty(clienteDto.Apellido))
                    clienteExistente.Apellido = clienteDto.Apellido;

                if (!string.IsNullOrEmpty(clienteDto.Telefono))
                    clienteExistente.Telefono = clienteDto.Telefono;

                if (!string.IsNullOrEmpty(clienteDto.Email))
                    clienteExistente.Email = clienteDto.Email;

                if (!string.IsNullOrEmpty(clienteDto.Direccion))
                    clienteExistente.Direccion = clienteDto.Direccion;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        // DELETE: api/Cliente/{numeroDocumento}
        [HttpDelete("{numeroDocumento}")]
        public async Task<IActionResult> Delete(string numeroDocumento)
        {
            try
            {
                var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC EliminarCliente @NumeroDocumento",
                    new SqlParameter("@NumeroDocumento", numeroDocumento)
                );

                if (rowsAffected > 0)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}
