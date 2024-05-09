using System.Reflection;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddScoped(typeof(ICalculateService), typeof(CalculateService));
builder.Services.AddScoped(typeof(IEvaluatorFuzzyCalculatorService), typeof(EvaluatorFuzzyCalculatorService));
// Add services to the container.

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

app.AddGlobalErrorHandler();

app.Run();