namespace WebApiFrituraV2.Middlewares
{
    public static class FileLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FileLoggingMiddleware>();
        }
    }
}
