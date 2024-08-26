using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.BelongingFunction;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using Profile = ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile.Profile;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParametersToAgents;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;

internal class ITProjectPriceCalculationManagerDbContext : DbContext
{
    public ITProjectPriceCalculationManagerDbContext(DbContextOptions<ITProjectPriceCalculationManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Application> Applications { get; set; }
    public DbSet<ApplicationForEvaluation> ApplicationForEvaluations { get; set; }
    public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
    public DbSet<ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
    public DbSet<BelongingFunction> BelongingFunctions { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EvaluateParameter> EvaluateParameters { get; set; }
    public DbSet<EvaluateParametersToAgents> EvaluateParametersToAgents { get; set; }
    public DbSet<Evaluator> Evaluators { get; set; }
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<ParameterValue> ParameterValues { get; set; }
    public DbSet<ProcedureApplication> ProcedureApplications { get; set; }
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationStatusConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationToEvaluatorConfiguration());
        modelBuilder.ApplyConfiguration(new BelongingFunctionConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EvaluateParameterConfiguration());
        modelBuilder.ApplyConfiguration(new EvaluateParametersToAgentsConfiguration());
        modelBuilder.ApplyConfiguration(new EvaluatorConfiguration());
        modelBuilder.ApplyConfiguration(new ParameterConfiguration());
        modelBuilder.ApplyConfiguration(new ParameterValueConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());

        modelBuilder.Seed();
    }
}