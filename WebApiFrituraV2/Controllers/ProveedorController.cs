using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApiFrituraV2.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiFrituraV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly TiendaFriturasDbContext _context;

        public ProveedorController(TiendaFriturasDbContext context)
        {
            _context = context; // Asignamos el contexto de la base de datos
        }
        public class ProveedorDto
        {
            public string NombreProveedor { get; set; }
            public string Descripcion { get; set; }
        }

        [HttpPost("RegistrarProveedor")]
        public async Task<IActionResult> RegistrarProveedor([FromBody] ProveedorDto proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest("Proveedor no puede ser nulo.");
            }

            try
            {
                // Parámetros del DTO
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@NombreProveedor", proveedor.NombreProveedor),
            new SqlParameter("@Descripcion", proveedor.Descripcion)
                };

                // Parámetro de salida para obtener el CodigoProveedor generado
                var proveedorIdParam = new SqlParameter("@CodigoProveedor", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                parameters = parameters.Append(proveedorIdParam).ToArray();

                // Ejecutamos el SP usando el DbContext
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_RegistrarProveedor @NombreProveedor, @Descripcion, @CodigoProveedor OUT", parameters);

                // Obtenemos el CodigoProveedor del parámetro de salida
                var proveedorId = (int)proveedorIdParam.Value;

                // Verificamos si la inserción fue exitosa
                if (proveedorId == 0)
                {
                    return StatusCode(500, "El proveedor no se pudo registrar correctamente.");
                }

                // Devolvemos la respuesta con el CodigoProveedor generado
                return Ok(new
                {
                    CodigoProveedor = proveedorId,
                    NombreProveedor = proveedor.NombreProveedor,
                    Descripcion = proveedor.Descripcion
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }



        [HttpGet("ListarProveedores")]
        public async Task<IActionResult> ListarProveedores()
        {
            var proveedores = await _context.Proveedores
                .Select(p => new
                {
                    p.CodigoProveedor,
                    p.NombreProveedor,
                    p.Descripcion
                })
                .ToListAsync();

            return Ok(proveedores);
        }

        [HttpGet("ConsultarProveedorPorID/{codigoProveedor}")]
        public async Task<IActionResult> ConsultarProveedorPorID(int codigoProveedor)
        {
            var parameters = new SqlParameter("@CodigoProveedor", codigoProveedor);

            var proveedor = _context.Proveedores
                .FromSqlRaw("EXEC ConsultarProveedorPorID @CodigoProveedor", parameters)
                .AsEnumerable()  // Proyección en memoria (debe ser sincronizada)
                .Select(p => new
                {
                    p.CodigoProveedor,
                    p.NombreProveedor,
                    p.Descripcion
                })
                .FirstOrDefault();

            if (proveedor == null)
            {
                return NotFound();  // Si no se encuentra el proveedor
            }

            return Ok(proveedor);  // Retorna el proveedor encontrado
        }

        [HttpPut("ActualizarProveedor/{codigoProveedor}")]
        public async Task<IActionResult> ActualizarProveedor(int codigoProveedor, [FromBody] ProveedorDto proveedorDto)
        {
            if (proveedorDto == null)
            {
                return BadRequest("Proveedor no puede ser nulo.");
            }

            try
            {
                var proveedorExistente = await _context.Proveedores
                    .FirstOrDefaultAsync(p => p.CodigoProveedor == codigoProveedor);

                if (proveedorExistente == null)
                {
                    return NotFound();
                }

                // Solo actualizamos los campos que han sido proporcionados en la solicitud
                if (!string.IsNullOrEmpty(proveedorDto.NombreProveedor))
                {
                    proveedorExistente.NombreProveedor = proveedorDto.NombreProveedor;
                }

                if (!string.IsNullOrEmpty(proveedorDto.Descripcion))
                {
                    proveedorExistente.Descripcion = proveedorDto.Descripcion;
                }

                // Guardamos los cambios
                await _context.SaveChangesAsync();

                return NoContent();  // Retorna NoContent si la actualización fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        [HttpDelete("EliminarProveedor/{codigoProveedor}")]
        public async Task<IActionResult> EliminarProveedor(int codigoProveedor)
        {
            try
            {
                var proveedor = await _context.Proveedores
                    .FirstOrDefaultAsync(p => p.CodigoProveedor == codigoProveedor);

                if (proveedor == null)
                {
                    return NotFound();
                }

                // Eliminar proveedor
                _context.Proveedores.Remove(proveedor);
                await _context.SaveChangesAsync();

                return NoContent();  // Devuelve NoContent si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }
    }
}
