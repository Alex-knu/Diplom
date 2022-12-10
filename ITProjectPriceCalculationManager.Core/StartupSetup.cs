using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ITProjectPriceCalculationManager.Core.Helpers;

namespace ITProjectPriceCalculationManager.Core
{
    public static class StartupSetup
    {
        public static void AddAutoMapper(this IServiceCollection services)
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ApplicationProfile());
                });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);
            }
    }
}
