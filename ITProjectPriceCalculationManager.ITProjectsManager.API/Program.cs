using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("ITProjectPriceCalculationManagerDbContext")));

        builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ITProjectPriceCalculationManagerDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            } 
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}