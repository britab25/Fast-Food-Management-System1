using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClienteJWT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // Los datos que enviarás al endpoint de login
            var loginData = new
            {
                UsuarioLogin = "MBenitez",  // Usuario de ejemplo
                ClaveHash = "CONTRASENA"    // Contraseña de ejemplo
            };

            // Realizamos la solicitud POST para obtener el token
            var response = await client.PostAsJsonAsync("https://localhost:44372/api/Usuario/Login", loginData);

            if (response.IsSuccessStatusCode)
            {
                // Si el login es exitoso, obtenemos el token
                var tokenResponse = await response.Content.ReadAsStringAsync();

                // Parseamos la respuesta JSON
                var jsonResponse = JsonSerializer.Deserialize<JsonElement>(tokenResponse);
                string token = jsonResponse.GetProperty("Token").GetString(); // Obtenemos el valor del token

                Console.WriteLine("Token JWT obtenido: ");
                Console.WriteLine(token);

                // Hacer una solicitud posterior a un endpoint protegido con el token JWT
                await FiltrarUsuariosPorRol(client, token);
            }
            else
            {
                Console.WriteLine("Login fallido.");
            }
        }

        // Método para hacer solicitudes protegidas con JWT
        static async Task FiltrarUsuariosPorRol(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:44372/api/Usuario/FiltrarPorRol?rol=ADMIN");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Usuarios filtrados:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Error al acceder a los usuarios filtrados.");
            }
        }
    }
}
