using System.Reflection;
using ITProjectPriceCalculationManager.DTOModels.Settings;
using ITProjectPriceCalculationManager.Extentions.Extentions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly(), true);
        // Add services to the container.

        var configuration = builder.Configuration.GetSection("RouteAPI").Get<RouteSetting>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpClient("ITProjectsCalculator", client =>
            {
                client.BaseAddress = new Uri(configuration.ITProjectsCalculatorAPIRoute);
            });
        builder.Services.AddHttpClient("ITProjectsManager", client =>
            {
                client.BaseAddress = new Uri(configuration.ITProjectsManagerAPIRoute);
            });

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

        app.AddGlobalErrorHandler();

        app.Run();
    }
}