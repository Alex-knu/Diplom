using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Stub;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x => x.UseNpgsql(builder.Configuration["ITProjectsManagerAPI:ConnectionString"]));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped(typeof(IApplicationService), typeof(StubApplicationService));

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
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();