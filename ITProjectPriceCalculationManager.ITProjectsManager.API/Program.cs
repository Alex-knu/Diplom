using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<ITProjectPriceCalculationManagerDbContext>(x => x.UseSqlServer(builder.Configuration["ITProjectsManagerAPI:ConnectionString"])); //UseSqlServer

JwtUtils.SecretKey = builder.Configuration["JWT:Secret"];
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped(typeof(IApplicationService), typeof(ApplicationService));
builder.Services.AddScoped(typeof(IApplicationInfoForEvaluationService), typeof(ApplicationInfoForEvaluationService));
builder.Services.AddScoped(typeof(IBaseApplicationService), typeof(BaseApplicationService));
builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddScoped(typeof(IDepartmentTreeService), typeof(DepartmentTreeService));
builder.Services.AddScoped(typeof(IEvaluationService), typeof(EvaluationService));
builder.Services.AddScoped(typeof(IEvaluatorService), typeof(EvaluatorService));
builder.Services.AddScoped(typeof(IProgramLanguageService), typeof(ProgramLanguageService));
builder.Services.AddScoped(typeof(IApplicationToEstimatorsService), typeof(ApplicationToEstimatorsService));
builder.Services.AddScoped(typeof(IEvaluationParametrsInfoService), typeof(EvaluationParametrsInfoService));
builder.Services.AddScoped(typeof(IApplicationToFactorsService), typeof(ApplicationToFactorsService));
//builder.Services.AddScoped(typeof(IApplicationService), typeof(StubApplicationService));

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

app.AddGlobalErrorHandler();

app.MapControllers();

app.Run();