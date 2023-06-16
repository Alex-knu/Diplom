using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute;
using Attribute = ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.SeedData;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationForEvaluation;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data
{
    internal class ITProjectPriceCalculationManagerDbContext : DbContext
    {
        public ITProjectPriceCalculationManagerDbContext(DbContextOptions<ITProjectPriceCalculationManagerDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationToEvaluatorConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationToFactorConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeToFactorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluatorConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluatorToEvaluatedFactorConfiguration());
            modelBuilder.ApplyConfiguration(new FactorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrToSubjectAreaElementConfiguration());

            modelBuilder.Seed();
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationForEvaluation> ApplicationForEvaluations { get; set; }
        public DbSet<ApplicationToEvaluator> ApplicationToEvaluators { get; set; }
        public DbSet<ApplicationToFactor> ApplicationToFactors { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<DifficultyLevelsType> DifficultyLevelsTypes { get; set; }
        public DbSet<DifficultyLevelsTypeToFactorType> DifficultyLevelsTypeToFactorTypes { get; set; }
        public DbSet<Evaluator> Evaluators { get; set; }
        public DbSet<EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactors { get; set; }
        public DbSet<FactorType> FactorTypes { get; set; }
        public DbSet<ProgramsParametr> ProgramsParametrs { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
        public DbSet<ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
        public DbSet<EvaluationAttribute> EvaluationAttributes { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
    }
}