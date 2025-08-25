using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Middlewares
{
    public static class FileLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FileLoggingMiddleware>();
        }
    }
}
