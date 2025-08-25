using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginTestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var usuarioLogin = "prueba1";
            var clave = "Clave123";  // Contraseña en texto plano

            var loginData = new
            {
                UsuarioLogin = usuarioLogin,
                ClaveHash = clave  // Aquí envías la contraseña tal cual, sin hash
            };

            using var client = new HttpClient();
            var url = "http://localhost:5263/api/Usuario/Login";

            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("Enviando solicitud de login...");
            try
            {
                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Login exitoso:");
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"Login fallido: {response.StatusCode}");
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Mensaje del servidor: {error}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de conexión HTTP: {ex.Message}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
