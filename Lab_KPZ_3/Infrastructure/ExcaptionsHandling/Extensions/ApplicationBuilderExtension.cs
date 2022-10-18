using Microsoft.AspNetCore.Builder;

namespace Lab_KPZ_3.Infrastructure.ExcaptionsHandling.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
