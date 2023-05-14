using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType
{
    internal class DifficultyLevelsTypeToFactorTypeConfiguration : IEntityTypeConfiguration<DifficultyLevelsTypeToFactorType>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevelsTypeToFactorType> builder)
        {
            builder.HasKey(applicationToEstimators => applicationToEstimators.Id);

            builder.Property(applicationToEstimators => applicationToEstimators.Value)
                .IsRequired();

            builder
                .HasOne(profile => profile.DifficultyLevel)
                .WithMany(estimator => estimator.DifficultyLevelsTypeToFactorTypes)
                .HasForeignKey(profile => profile.DifficultyLevelId);

            builder
                .HasOne(profile => profile.Factor)
                .WithMany(estimator => estimator.DifficultyLevelsTypeToFactorTypes)
                .HasForeignKey(profile => profile.FactorId);

            builder
                .HasOne(profile => profile.FactorType)
                .WithMany(estimator => estimator.DifficultyLevelsTypeToFactorTypes)
                .HasForeignKey(profile => profile.FactorTypeId);
            
            builder.HasData(
                //Factor - Internal logical object
                new DifficultyLevelsTypeToFactorType { Id = 1, DifficultyLevelId = 3, FactorId = 13, FactorTypeId = 3, Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = 2, DifficultyLevelId = 5, FactorId = 13, FactorTypeId = 3, Value = 10 },
                new DifficultyLevelsTypeToFactorType { Id = 3, DifficultyLevelId = 6, FactorId = 13, FactorTypeId = 3, Value = 15 },
                //Factor - External interface object
                new DifficultyLevelsTypeToFactorType { Id = 4, DifficultyLevelId = 3, FactorId = 14, FactorTypeId = 4, Value = 5 },
                new DifficultyLevelsTypeToFactorType { Id = 5, DifficultyLevelId = 5, FactorId = 14, FactorTypeId = 4, Value = 7 },
                new DifficultyLevelsTypeToFactorType { Id = 6, DifficultyLevelId = 6, FactorId = 14, FactorTypeId = 4, Value = 10 },
                //Factor - Qualifications(PERS)
                new DifficultyLevelsTypeToFactorType { Id = 7, DifficultyLevelId = 1, FactorId = 1, FactorTypeId = 2, Value = 2.12 },
                new DifficultyLevelsTypeToFactorType { Id = 8, DifficultyLevelId = 2, FactorId = 1, FactorTypeId = 2, Value = 1.62 },
                new DifficultyLevelsTypeToFactorType { Id = 9, DifficultyLevelId = 3, FactorId = 1, FactorTypeId = 2, Value = 1.26 },
                new DifficultyLevelsTypeToFactorType { Id = 10, DifficultyLevelId = 4, FactorId = 1, FactorTypeId = 2, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 11, DifficultyLevelId = 6, FactorId = 1, FactorTypeId = 2, Value = 0.83 },
                new DifficultyLevelsTypeToFactorType { Id = 12, DifficultyLevelId = 7, FactorId = 1, FactorTypeId = 2, Value = 0.63 },
                new DifficultyLevelsTypeToFactorType { Id = 13, DifficultyLevelId = 8, FactorId = 1, FactorTypeId = 2, Value = 0.5 },
                //Factor - Experience(PREX)
                new DifficultyLevelsTypeToFactorType { Id = 14, DifficultyLevelId = 1, FactorId = 2, FactorTypeId = 2, Value = 1.59 },
                new DifficultyLevelsTypeToFactorType { Id = 15, DifficultyLevelId = 2, FactorId = 2, FactorTypeId = 2, Value = 1.33 },
                new DifficultyLevelsTypeToFactorType { Id = 16, DifficultyLevelId = 3, FactorId = 2, FactorTypeId = 2, Value = 1.12 },
                new DifficultyLevelsTypeToFactorType { Id = 17, DifficultyLevelId = 4, FactorId = 2, FactorTypeId = 2, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 18, DifficultyLevelId = 6, FactorId = 2, FactorTypeId = 2, Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = 19, DifficultyLevelId = 7, FactorId = 2, FactorTypeId = 2, Value = 0.71 },
                new DifficultyLevelsTypeToFactorType { Id = 20, DifficultyLevelId = 8, FactorId = 2, FactorTypeId = 2, Value = 0.62 },
                //Factor - Technical support(FCIL)
                new DifficultyLevelsTypeToFactorType { Id = 21, DifficultyLevelId = 1, FactorId = 3, FactorTypeId = 2, Value = 1.43 },
                new DifficultyLevelsTypeToFactorType { Id = 22, DifficultyLevelId = 2, FactorId = 3, FactorTypeId = 2, Value = 1.3 },
                new DifficultyLevelsTypeToFactorType { Id = 23, DifficultyLevelId = 3, FactorId = 3, FactorTypeId = 2, Value = 1.1 },
                new DifficultyLevelsTypeToFactorType { Id = 24, DifficultyLevelId = 4, FactorId = 3, FactorTypeId = 2, Value = 1 },
                new DifficultyLevelsTypeToFactorType { Id = 25, DifficultyLevelId = 6, FactorId = 3, FactorTypeId = 2, Value = 0.87 },
                new DifficultyLevelsTypeToFactorType { Id = 26, DifficultyLevelId = 7, FactorId = 3, FactorTypeId = 2, Value = 0.73 },
                new DifficultyLevelsTypeToFactorType { Id = 27, DifficultyLevelId = 8, FactorId = 3, FactorTypeId = 2, Value = 0.62 }
            );
        }
    }
}