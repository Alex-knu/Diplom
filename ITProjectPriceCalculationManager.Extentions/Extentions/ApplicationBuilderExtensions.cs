using ITProjectPriceCalculationManager.Extentions.Handlers;
using Microsoft.AspNetCore.Builder;

namespace ITProjectPriceCalculationManager.Extentions.Extentions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder) => applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}