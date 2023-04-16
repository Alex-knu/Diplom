using System.Reflection;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Models;
using ITProjectPriceCalculationManager.AuthServer.Core.Entities.ApplicationUser;
using ITProjectPriceCalculationManager.AuthServer.Core.Factories;
using ITProjectPriceCalculationManager.AuthServer.Infrastructure.Data;
using ITProjectPriceCalculationManager.DTOModels.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration
            .AddEnvironmentVariables()
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

        var configuration = builder.Configuration.GetSection("AuthServer").Get<AuthServerSetting>();

        // Add services to the container.
        //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddDbContext<AuthServerDbContext>(options =>
            options.UseNpgsql(configuration.ConnectionString, npgsqlDbContexOptionsBuilder =>
                {
                    NpgsqlOptionsAction(npgsqlDbContexOptionsBuilder);
                }
            )
        );

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AuthServerDbContext>();

        builder.Services.AddIdentityServer()
            .AddAspNetIdentity<ApplicationUser>()
            .AddConfigurationStore(configurationOptions =>
                {
                    configurationOptions.ResolveDbContextOptions = (sericeProvider, option) =>
                    {
                        ResolveDbContextOptions(option, configuration.ConnectionString);
                    };
                })
            .AddOperationalStore(configurationOptions =>
                {
                    configurationOptions.ResolveDbContextOptions = (sericeProvider, option) =>
                    {
                        ResolveDbContextOptions(option, configuration.ConnectionString);
                    };
                });

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
        //}

        //app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseIdentityServer();

        app.MapControllers();

        app.Run();
        // if (app.Environment.IsDevelopment())
        // {
        using var scope = app.Services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<AuthServerDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.MigrateAsync();
        await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (await userManager.FindByNameAsync("thomas.clark") == null)
        {
            await userManager.CreateAsync(
                new ApplicationUser
                {
                    UserName = "thomas.clark",
                    Email = "thomas.clark@example.com",
                    FirstName = "Thomas",
                    LastName = "Clark"
                }, "Pa55w0rd!");
        }

        var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

        if (!await configurationDbContext.ApiResources.AnyAsync())
        {
            await configurationDbContext.ApiResources.AddAsync(new ApiResource
            {
                Name = "9fc33c2e-dbc1-4d0a-b212-68b9e07b3ba0",
                DisplayName = "API",
                Scopes = new List<string> { "https://www.example.com/api" }
            }.ToEntity());


            await configurationDbContext.SaveChangesAsync();
        }

        if (!await configurationDbContext.ApiScopes.AnyAsync())
        {
            await configurationDbContext.ApiScopes.AddAsync(new ApiScope
            {
                Name = "https://www.example.com/api",
                DisplayName = "API"
            }.ToEntity());

            await configurationDbContext.SaveChangesAsync();
        }

        if (!await configurationDbContext.Clients.AnyAsync())
        {
            await configurationDbContext.Clients.AddRangeAsync(
                new Client
                {
                    ClientId = "b4e758d2-f13d-4a1e-bf38-cc88f4e290e1",
                    ClientSecrets = new List<Secret> { new("secret".Sha512()) },
                    ClientName = "Console Application",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string> { "https://www.example.com/api" },
                    AllowedCorsOrigins = new List<string> { "https://api:7001" }
                }.ToEntity(),
                new Client
                {
                    ClientId = "4ecc4153-daf9-4eca-8b60-818a63637a81",
                    ClientSecrets = new List<Secret> { new("secret".Sha512()) },
                    ClientName = "Web Application",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string> { "openid", "profile", "email", "https://www.example.com/api" },
                    RedirectUris = new List<string> { "https://webapplication:7002/signin-oidc" },
                    PostLogoutRedirectUris = new List<string> { "https://webapplication:7002/signout-callback-oidc" }
                }.ToEntity(),
                new Client
                {
                    ClientId = "7e98ad57-540a-4191-b477-03d88b8187e1",
                    RequireClientSecret = false,
                    ClientName = "Single Page Application",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string> { "openid", "profile", "email", "https://www.example.com/api" },
                    AllowedCorsOrigins = new List<string> { "http://singlepageapplication:7003" },
                    RedirectUris =
                        new List<string> { "http://singlepageapplication:7003/authentication/login-callback" },
                    PostLogoutRedirectUris = new List<string>
                    {
                    "http://singlepageapplication:7003/authentication/logout-callback"
                    }
                }.ToEntity());

            await configurationDbContext.SaveChangesAsync();
        }

        if (!await configurationDbContext.IdentityResources.AnyAsync())
        {
            await configurationDbContext.IdentityResources.AddRangeAsync(
                new IdentityResources.OpenId().ToEntity(),
                new IdentityResources.Profile().ToEntity(),
                new IdentityResources.Email().ToEntity());

            await configurationDbContext.SaveChangesAsync();
        }
        //}

        void ResolveDbContextOptions(DbContextOptionsBuilder option, string connectionString)
        {
            option.UseNpgsql(connectionString, NpgsqlOptionsAction);
        }

        void NpgsqlOptionsAction(NpgsqlDbContextOptionsBuilder npgsqlDbContexOptionsBuilder)
        {
            npgsqlDbContexOptionsBuilder.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
        }
    }
}