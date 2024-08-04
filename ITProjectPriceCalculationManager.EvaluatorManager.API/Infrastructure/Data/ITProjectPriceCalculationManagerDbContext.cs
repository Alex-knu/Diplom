using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data;

public class ITProjectPriceCalculationEvaluatorManagerDbContext : DbContext
{
    public ITProjectPriceCalculationEvaluatorManagerDbContext(DbContextOptions<ITProjectPriceCalculationEvaluatorManagerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BelongingFunctionConfiguration());
        modelBuilder.ApplyConfiguration(new EvaluateParameterConfiguration());
        modelBuilder.ApplyConfiguration(new ParametersConfiguration());
        modelBuilder.ApplyConfiguration(new ParameterValueConfiguration());

        modelBuilder.Seed();
    }


    public DbSet<BelongingFunction> BelongingFunction { get; set; }
    public DbSet<EvaluateParameter> EvaluateParameter { get; set; }
    public DbSet<Parameters> Parameters { get; set; }
    public DbSet<ParameterValue> ParameterValue { get; set; }
}