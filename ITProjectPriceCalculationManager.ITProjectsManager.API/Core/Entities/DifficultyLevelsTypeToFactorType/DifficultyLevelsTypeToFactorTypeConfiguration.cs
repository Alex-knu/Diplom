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
        }
    }
}