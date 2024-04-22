using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;

internal class ApplicationToFactorConfiguration : IEntityTypeConfiguration<ApplicationToFactor>
{
    public void Configure(EntityTypeBuilder<ApplicationToFactor> builder)
    {
        builder.HasKey(estimator => estimator.Id);

        builder
            .HasOne(profile => profile.Application)
            .WithMany(estimator => estimator.Factors)
            .HasForeignKey(profile => profile.ApplicationId);

        builder
            .HasOne(profile => profile.DifficultyLevelsTypeToFactorType)
            .WithMany(estimator => estimator.ApplicationToFactors)
            .HasForeignKey(profile => profile.DifficultyLevelsTypeToFactorTypeId);

        builder.Property(estimator => estimator.Value)
            .IsRequired();
    }
}