using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Infrastructure.Interfaces;
using ITProjectPriceCalculationManager.Infrastructure.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x =>
    x.UseSqlServer(builder.Configuration["ConnectionString"])); //UseSqlServer

JwtUtils.SecretKey = builder.Configuration["Secret"] ?? string.Empty;
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IRepository<,,>), typeof(BaseRepository<,,>));
builder.Services.AddScoped(typeof(IApplicationService), typeof(ApplicationService));
builder.Services.AddScoped(typeof(IApplicationToEstimatorsService), typeof(ApplicationToEstimatorsService));
builder.Services.AddScoped(typeof(IBaseApplicationService), typeof(BaseApplicationService));
builder.Services.AddScoped(typeof(IBelongingFunctionService), typeof(BelongingFunctionService));
builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddScoped(typeof(IDepartmentTreeService), typeof(DepartmentTreeService));
builder.Services.AddScoped(typeof(IEvaluateParameterService), typeof(EvaluateParameterService));
builder.Services.AddScoped(typeof(IEvaluatorService), typeof(EvaluatorService));
builder.Services.AddScoped(typeof(IParametersService), typeof(ParametersService));
builder.Services.AddScoped(typeof(IParameterValueService), typeof(ParameterValueService));
//builder.Services.AddScoped(typeof(IApplicationService), typeof(StubApplicationService));

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ITProjectPriceCalculationManagerDbContext>();
    if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseAuthorization();

app.AddGlobalErrorHandler();

app.MapControllers();

app.Run();