using ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data;

internal class ITProjectPriceCalculationEvaluatorManagerDbContext : DbContext
{
    public ITProjectPriceCalculationEvaluatorManagerDbContext(
        DbContextOptions<ITProjectPriceCalculationEvaluatorManagerDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
        // modelBuilder.ApplyConfiguration(new ApplicationStatusConfiguration());
        // modelBuilder.ApplyConfiguration(new ApplicationToEvaluatorConfiguration());
        // modelBuilder.ApplyConfiguration(new ApplicationToFactorConfiguration());
        // modelBuilder.ApplyConfiguration(new AttributeConfiguration());
        // modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeConfiguration());
        // modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeToFactorTypeConfiguration());
        // modelBuilder.ApplyConfiguration(new EvaluatorConfiguration());
        // modelBuilder.ApplyConfiguration(new EvaluatorToEvaluatedFactorConfiguration());
        // modelBuilder.ApplyConfiguration(new FactorTypeConfiguration());
        // modelBuilder.ApplyConfiguration(new ProgramsParametrConfiguration());
        // modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
        // modelBuilder.ApplyConfiguration(new ProgramsParametrToSubjectAreaElementConfiguration());

        modelBuilder.Seed();
    }

    // public DbSet<Application> Applications { get; set; }
    // public DbSet<ApplicationForEvaluation> ApplicationForEvaluations { get; set; }
    // public DbSet<ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
    // public DbSet<ApplicationToFactor> ApplicationToFactors { get; set; }
    // public DbSet<Attribute> Attributes { get; set; }
    // public DbSet<DifficultyLevelsType> DifficultyLevelsTypes { get; set; }
    // public DbSet<DifficultyLevelsTypeToFactorType> DifficultyLevelsTypeToFactorTypes { get; set; }
    // public DbSet<Evaluator> Evaluators { get; set; }
    // public DbSet<EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactors { get; set; }
    // public DbSet<FactorType> FactorTypes { get; set; }
    // public DbSet<ProgramsParametr> ProgramsParametrs { get; set; }
    // public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
    // public DbSet<ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
    // public DbSet<EvaluationAttribute> EvaluationAttributes { get; set; }
    // public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
    // public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
    // public DbSet<ProcedureApplication> ProcedureApplications { get; set; }
}