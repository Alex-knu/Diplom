using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Stub;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("ITProjectsManagerAPI:ConnectionString")));

        builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
        builder.Services.AddScoped(typeof(IApplicationService), typeof(StubApplicationService));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        app.UseSwagger();
        app.UseSwaggerUI();
        // }

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}