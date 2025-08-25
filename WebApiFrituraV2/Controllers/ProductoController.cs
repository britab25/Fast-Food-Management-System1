using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiFrituraV2.Models;

namespace WebApiFrituraV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly TiendaFriturasDbContext _context;

        public ProductoController(TiendaFriturasDbContext context)
        {
            _context = context; // Asignamos el contexto de la base de datos
        }
        public class ProductoDto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public string Categoria { get; set; }
            public int Stock { get; set; }
            public string Descripcion { get; set; }
            public int CodigoInventario { get; set; }
            public int CodigoProveedor { get; set; }
        }

        [HttpPost("RegistrarProducto")]
        public async Task<IActionResult> RegistrarProducto([FromBody] ProductoDto producto)
        {
            if (producto == null)
            {
                return BadRequest("Producto no puede ser nulo.");
            }

            try
            {
                // Parámetros del DTO
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@Nombre", producto.Nombre),
            new SqlParameter("@Precio", producto.Precio),
            new SqlParameter("@Categoria", producto.Categoria),
            new SqlParameter("@Stock", producto.Stock),
            new SqlParameter("@Descripcion", producto.Descripcion),
            new SqlParameter("@CodigoInventario", producto.CodigoInventario),
            new SqlParameter("@CodigoProveedor", producto.CodigoProveedor)
                };

                // Parámetro de salida para obtener el ProductoID generado
                var productoIdParam = new SqlParameter("@ProductoID", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                parameters = parameters.Append(productoIdParam).ToArray();

                // Ejecutamos el SP usando el DbContext
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_RegistrarProducto @Nombre, @Precio, @Categoria, @Stock, @Descripcion, @CodigoInventario, @CodigoProveedor, @ProductoID OUT", parameters);

                // Obtenemos el ProductoID del parámetro de salida
                var productoId = (int)productoIdParam.Value;

                // Verificamos si la inserción fue exitosa
                if (productoId == 0)
                {
                    return StatusCode(500, "El producto no se pudo registrar correctamente.");
                }

                // Devolvemos la respuesta con el ProductoID generado
                return Ok(new
                {
                    ProductoID = productoId,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Categoria = producto.Categoria,
                    Stock = producto.Stock,
                    Descripcion = producto.Descripcion,
                    CodigoInventario = producto.CodigoInventario,
                    CodigoProveedor = producto.CodigoProveedor
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        [HttpGet("ObtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _context.Productos
                .Select(p => new
                {
                    p.ProductoId,
                    p.Nombre,
                    p.Precio,
                    p.Categoria,
                    p.Stock,
                    p.Descripcion,
                    p.CodigoInventario,
                    p.CodigoProveedor
                })
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet("ConsultarProductoPorID/{id}")]
        public async Task<IActionResult> ConsultarProductoPorID(int id)
        {
            var parameters = new SqlParameter("@ProductoID", id);

            // Ejecutar la consulta SQL y proyectar los resultados usando AsEnumerable()
            var producto = _context.Productos
                .FromSqlRaw("EXEC ConsultarProductoPorID @ProductoID", parameters)
                .AsEnumerable()  // Proyección en memoria (debe ser sincronizada)
                .Select(p => new
                {
                    p.ProductoId,
                    p.Nombre,
                    p.Precio,
                    p.Categoria,
                    p.Stock,
                    p.Descripcion,
                    p.CodigoInventario,
                    p.CodigoProveedor
                })
                .FirstOrDefault();  // Realizamos la proyección en memoria y obtenemos el primer resultado

            if (producto == null)
            {
                return NotFound();  // Si no se encuentra el producto
            }

            return Ok(producto);  // Retorna el producto encontrado
        }

        [HttpPut("ActualizarProducto/{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] ProductoDto productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            try
            {
                // Buscar el producto existente por su ID
                var productoExistente = await _context.Productos
                    .FirstOrDefaultAsync(p => p.ProductoId == id);

                if (productoExistente == null)
                {
                    return NotFound();  // Si el producto no existe
                }

                // Actualizar solo los campos que han sido proporcionados en la solicitud
                if (!string.IsNullOrEmpty(productoDto.Nombre))
                {
                    productoExistente.Nombre = productoDto.Nombre;
                }

                if (productoDto.Precio > 0)
                {
                    productoExistente.Precio = productoDto.Precio;
                }

                if (!string.IsNullOrEmpty(productoDto.Categoria))
                {
                    productoExistente.Categoria = productoDto.Categoria;
                }

                if (productoDto.Stock >= 0)  // Solo si el stock es mayor o igual a 0
                {
                    productoExistente.Stock = productoDto.Stock;
                }

                if (!string.IsNullOrEmpty(productoDto.Descripcion))
                {
                    productoExistente.Descripcion = productoDto.Descripcion;
                }

                if (productoDto.CodigoInventario > 0)  // Solo si el Código de Inventario es mayor que 0
                {
                    productoExistente.CodigoInventario = productoDto.CodigoInventario;
                }

                if (productoDto.CodigoProveedor > 0)  // Solo si el Código de Proveedor es mayor que 0
                {
                    productoExistente.CodigoProveedor = productoDto.CodigoProveedor;
                }

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();

                return NoContent();  // Devuelve un 204 No Content si la actualización fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }


        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            try
            {
                // Buscar el producto existente por su ID
                var producto = await _context.Productos
                    .FirstOrDefaultAsync(p => p.ProductoId == id);

                if (producto == null)
                {
                    return NotFound();  // Si el producto no existe
                }

                // Eliminar el producto
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();

                return NoContent();  // Devuelve un 204 No Content si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }


    }
}
