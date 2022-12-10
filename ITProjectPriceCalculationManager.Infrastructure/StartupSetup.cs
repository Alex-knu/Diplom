using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ITProjectPriceCalculationManager.Core.Interfaces;
using ITProjectPriceCalculationManager.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.Infrastructure.Data;
using ITProjectPriceCalculationManager.Infrastructure.Data.Repositories;

namespace ITProjectPriceCalculationManager.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
        }

        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x => x.UseNpgsql(connectionString));
        }
    }
}