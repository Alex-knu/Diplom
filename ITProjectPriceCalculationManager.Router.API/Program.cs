using System.Reflection;
using System.Text;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Models;
using ITProjectPriceCalculationManager.Router.API.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
// Add services to the container.

var routeConfiguration = builder.Configuration.GetSection("RouteAPI").Get<RouteSetting>();
var jwtConfiguration = builder.Configuration.GetSection("JWT").Get<JwtSetting>();
JwtUtils.SecretKey = jwtConfiguration.Secret;

builder.Services.AddScoped(typeof(IRouteService), typeof(RouteService));
builder.Services.AddScoped(typeof(IApplicationService), typeof(ApplicationService));
builder.Services.AddScoped(typeof(IBaseApplicationService), typeof(BaseApplicationService));
builder.Services.AddScoped(typeof(IDepartmentService), typeof(DepartmentService));
builder.Services.AddScoped(typeof(IDepartmentTreeService), typeof(DepartmentTreeService));
builder.Services.AddScoped(typeof(IEvaluationService), typeof(EvaluationService));
builder.Services.AddScoped(typeof(IEvaluatorService), typeof(EvaluatorService));
builder.Services.AddScoped(typeof(IProgramLanguageService), typeof(ProgramLanguageService));
builder.Services.AddScoped(typeof(IApplicationToEstimatorsService), typeof(ApplicationToEstimatorsService));
builder.Services.AddScoped(typeof(IDifficultyLevelsTypeService), typeof(DifficultyLevelsTypeService));
builder.Services.AddScoped(typeof(IEvaluationParametrsInfoService), typeof(EvaluationParametrsInfoService));
builder.Services.AddScoped(typeof(IApplicationToFactorsService), typeof(ApplicationToFactorsService));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHttpClient("ITProjectsCalculator", client =>
    {
        client.BaseAddress = new Uri(routeConfiguration.ITProjectsCalculatorAPIRoute);
    });
builder.Services
    .AddHttpClient("ITProjectsManager", client =>
    {
        client.BaseAddress = new Uri(routeConfiguration.ITProjectsManagerAPIRoute);
    });

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = jwtConfiguration.ValidAudience,
            ValidIssuer = jwtConfiguration.ValidIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret))
        };
    });

var app = builder.Build();

app.UseCors(
    builder => builder
        .WithOrigins(routeConfiguration.OriginUrls)
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();