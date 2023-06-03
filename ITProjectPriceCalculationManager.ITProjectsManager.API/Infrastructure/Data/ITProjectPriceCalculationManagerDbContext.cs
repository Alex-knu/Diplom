using Microsoft.EntityFrameworkCore;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute;
using Attribute = ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data.SeedData;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluationAttributes;

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
            modelBuilder.ApplyConfiguration(new ApplicationToEstimatorsConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationToFactorsConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DifficultyLevelsTypeToFactorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EstimatorConfiguration());
            modelBuilder.ApplyConfiguration(new EvaluatorToEvaluatedFactorConfiguration());
            modelBuilder.ApplyConfiguration(new FactorTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramsParametrToSubjectAreaElementConfiguration());

            modelBuilder.Seed();
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationToEstimators> ApplicationToEstimators { get; set; }
        public DbSet<ApplicationToFactors> ApplicationToFactors { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<DifficultyLevelsType> DifficultyLevelsTypes { get; set; }
        public DbSet<DifficultyLevelsTypeToFactorType> DifficultyLevelsTypeToFactorTypes { get; set; }
        public DbSet<Estimator> Estimators { get; set; }
        public DbSet<EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactors { get; set; }
        public DbSet<FactorType> FactorTypes { get; set; }
        public DbSet<ProgramsParametr> ProgramsParametrs { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
        public DbSet<ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
        public DbSet<EvaluationAttribute> EvaluationAttributes { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }

        public virtual IEnumerable<DifficultyLevelsTypeDTO> GetDifficultyLevelTypesForFactorType(int factorTypeId)
        {
            return (from dlttft in DifficultyLevelsTypeToFactorTypes
                    join ft in FactorTypes on dlttft.FactorTypeId equals ft.Id
                    join dlt in DifficultyLevelsTypes on dlttft.DifficultyLevelId equals dlt.Id
                    where ft.Id == factorTypeId
                    orderby dlt.Id
                    select new DifficultyLevelsTypeDTO()
                    {
                        Id = dlt.Id,
                        Name = dlt.Name
                    }).Distinct();
        }

        public virtual IEnumerable<EvaluationParametrsInfoDTO> GetEvaluationAttributes()
        {
            return (from dlttft in DifficultyLevelsTypeToFactorTypes
                    join a in Attributes on dlttft.FactorId equals a.Id
                    join ft in FactorTypes on dlttft.FactorTypeId equals ft.Id
                    orderby ft.Id
                    select new EvaluationParametrsInfoDTO()
                    {
                        Name = a.Name,
                        FactorTypeId = ft.Id,
                        DifficultyLevels = (from dlttft in DifficultyLevelsTypeToFactorTypes
                                            join dlt in DifficultyLevelsTypes on dlttft.DifficultyLevelId equals dlt.Id
                                            where dlttft.FactorId == a.Id
                                            orderby dlt.Id
                                            select new DifficultyLevelsTypeDTO()
                                            {
                                                Id = dlt.Id,
                                                RelationId = dlttft.Id,
                                                Name = dlt.Name
                                            }).ToList()
                    });
        }
    }
}