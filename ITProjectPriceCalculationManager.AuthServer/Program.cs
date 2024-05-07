using System.Reflection;
using System.Text;
using ITProjectPriceCalculationManager.AuthServer.Core.Interfaces.Services;
using ITProjectPriceCalculationManager.AuthServer.Core.Models;
using ITProjectPriceCalculationManager.AuthServer.Core.Services;
using ITProjectPriceCalculationManager.AuthServer.Infrastructure;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true);
// Add services to the container.

var configuration = builder.Configuration.GetSection("AuthServer").Get<AuthServerSetting>();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionString"])); //UseSqlServer

builder.Services.AddScoped(typeof(IAuthenticateSevice), typeof(AuthenticateSevice));
builder.Services.AddScoped(typeof(IUserSevice), typeof(UserSevice));
builder.Services.AddScoped(typeof(IRoleSevice), typeof(RoleSevice));

// For Identity
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
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
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
}

app.UseStaticFiles();
app.UseCors(
    b => b
        .WithOrigins(builder.Configuration["OriginUrls"].Split(','))
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();