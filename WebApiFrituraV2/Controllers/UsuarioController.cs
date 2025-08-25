using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiFrituraV2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;




namespace WebApiFrituraV2.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TiendaFriturasDbContext _context;
        public UsuarioController(TiendaFriturasDbContext context)
        {
            _context = context;
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDto usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            try
            {
                // Parámetros del DTO
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@UsuarioLogin", usuario.UsuarioLogin),
            new SqlParameter("@ClaveHash", usuario.ClaveHash),
            new SqlParameter("@Nombre", usuario.Nombre),
            new SqlParameter("@Rol", usuario.Rol)
                };

                // Parámetro de salida para obtener el UsuarioID generado
                var usuarioIdParam = new SqlParameter("@UsuarioID", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                parameters = parameters.Append(usuarioIdParam).ToArray();

                // Ejecutamos el SP usando el DbContext
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_RegistrarUsuario @UsuarioLogin, @ClaveHash, @Nombre, @Rol, @UsuarioID OUT", parameters);

                // Obtenemos el UsuarioID del parámetro de salida
                var usuarioId = (int)usuarioIdParam.Value;

                // Verificamos si la inserción fue exitosa
                if (usuarioId == 0)
                {
                    return StatusCode(500, "El usuario no se pudo registrar correctamente.");
                }

                // Devolvemos la respuesta con el UsuarioID generado
                return Ok(new
                {
                    UsuarioID = usuarioId,
                    usuario.UsuarioLogin,
                    usuario.Nombre,
                    usuario.Rol,
                    FechaIngreso = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (login == null)
            {
                return BadRequest("El login no puede ser nulo.");
            }

            try
            {
                var parameters = new SqlParameter[]
                {
            new SqlParameter("@UsuarioLogin", login.UsuarioLogin),
            new SqlParameter("@ClaveHash", login.ClaveHash)
                };

                var usuario = _context.Usuarios
                    .FromSqlRaw("EXEC sp_VerificarLogin @UsuarioLogin, @ClaveHash", parameters)
                    .AsEnumerable()
                    .Select(u => new
                    {
                        u.UsuarioId,
                        u.Nombre,
                        u.UsuarioLogin,
                        u.ClaveHash,
                        u.Rol,
                        u.FechaIngreso
                    })
                    .FirstOrDefault();

                if (usuario == null)
                {
                    return Unauthorized("Credenciales inválidas.");
                }

                // ✅ Generar el token JWT
                string token = GenerateJwtToken(usuario.UsuarioId, usuario.Nombre, usuario.Rol);

                return Ok(new
                {
                    Token = token,
                    UsuarioId = usuario.UsuarioId,
                    Nombre = usuario.Nombre
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.UsuarioId == id)
                .Select(u => new
                {
                    u.UsuarioId,
                    u.Nombre,
                    u.UsuarioLogin,
                    u.Rol,
                    u.FechaIngreso
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            try
            {
                // Buscar el usuario existente por su ID
                var usuarioExistente = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.UsuarioId == id);

                if (usuarioExistente == null)
                {
                    return NotFound();  // Si el usuario no existe
                }

                // Actualizar solo los campos que han sido proporcionados en la solicitud
                // Comprobar si cada propiedad es diferente de null o está vacía y, si es así, actualizarla

                if (!string.IsNullOrEmpty(usuarioDto.Nombre))
                {
                    usuarioExistente.Nombre = usuarioDto.Nombre;
                }

                if (!string.IsNullOrEmpty(usuarioDto.Rol))
                {
                    usuarioExistente.Rol = usuarioDto.Rol;
                }

                if (!string.IsNullOrEmpty(usuarioDto.UsuarioLogin))
                {
                    usuarioExistente.UsuarioLogin = usuarioDto.UsuarioLogin;
                }

                if (!string.IsNullOrEmpty(usuarioDto.ClaveHash)) // Si la contraseña está vacía, no se actualizará
                {
                    usuarioExistente.ClaveHash = usuarioDto.ClaveHash;
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {
                // Buscar el usuario existente por su ID
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.UsuarioId == id);

                if (usuario == null)
                {
                    return NotFound();  // Si el usuario no existe
                }

                // Eliminar el usuario
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return NoContent();  // Devuelve un 204 No Content si la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

        public class UsuarioDto
        {
            public string Nombre { get; set; } // Nombre del usuario
            public string UsuarioLogin { get; set; } // Nombre de usuario para login
            public string ClaveHash { get; set; } // Contraseña del usuario, debe ser en forma de hash
            public string Rol { get; set; } // Rol del usuario (Ej. Admin, Usuario, etc.)
        }

        public class LoginDto
        {
            public string UsuarioLogin { get; set; } // Nombre de usuario para login
            public string ClaveHash { get; set; } // Contraseña del usuario, en hash
        }

        // Endpoint para filtrar usuarios por rol

        [HttpGet("ListarUsuarios")]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var usuarios = await _context.Usuarios
                    .Select(u => new {
                        u.UsuarioId,
                        u.Nombre,
                        u.Rol,
                        u.UsuarioLogin
                    })
                    .ToListAsync();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar usuarios: {ex.Message}");
            }
        }
        private string GenerateJwtToken(int usuarioId, string nombre, string rol)
        {
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, nombre),
        new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),  // UsuarioId como NameIdentifier
        new Claim(ClaimTypes.Role, rol)  // Rol del usuario
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey1234567890YourSecretKey12"));  // 32 caracteres
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",  // El emisor del token
                audience: "YourAudience",  // La audiencia del token
                claims: claims,
                expires: DateTime.Now.AddHours(1),  // Define el tiempo de expiración del token
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);  // Retorna el token generado
        }




    }
}
