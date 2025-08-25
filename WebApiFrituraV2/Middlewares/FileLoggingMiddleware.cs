using System.Text;

namespace WebApiFrituraV2.Middlewares
{
    public class FileLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;

        public FileLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logFilePath = Path.Combine(AppContext.BaseDirectory, "logs", "api-log.txt");
            Console.WriteLine("📄 Log file path: " + _logFilePath);
            var logDir = Path.GetDirectoryName(_logFilePath);
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("➡️ Middleware de logging ejecutado."); // 👈 Aquí

            context.Request.EnableBuffering();

            string requestBody = "";
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            string responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                $"Usuario: {(context.User.Identity?.Name ?? "Anónimo")} | " +
                $"Método: {context.Request.Method} | Ruta: {context.Request.Path} | " +
                $"Query: {context.Request.QueryString} | " +
                $"Request Body: {requestBody} | Estado: {context.Response.StatusCode} | " +
                $"Response Body: {responseBodyText}\n";

            await File.AppendAllTextAsync(_logFilePath, logEntry);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}

