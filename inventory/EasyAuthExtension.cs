using Microsoft.AspNetCore.Builder;

namespace inventory
{
    public static class EasyAuthUserValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseEasyAuthUserValidation(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EasyAuthUserValidationMiddleware>();
        }
    }
}