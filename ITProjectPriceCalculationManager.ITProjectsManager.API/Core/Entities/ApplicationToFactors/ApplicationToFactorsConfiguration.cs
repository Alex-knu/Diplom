using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors
{
    internal class ApplicationToFactorsConfiguration : IEntityTypeConfiguration<ApplicationToFactors>
    {
        public void Configure(EntityTypeBuilder<ApplicationToFactors> builder)
        {
            builder
                   .HasKey(estimator => estimator.Id);

            builder
                .HasOne(profile => profile.Application)
                .WithMany(estimator => estimator.Factors)
                .HasForeignKey(profile => profile.ApplicationId);

            builder
                .HasOne(profile => profile.Factor)
                .WithMany(estimator => estimator.ApplicationToFactors)
                .HasForeignKey(profile => profile.FactorId);
            
            builder
                .HasOne(profile => profile.FactorType)
                .WithMany(estimator => estimator.ApplicationToFactors)
                .HasForeignKey(profile => profile.FactorTypeId);

            builder
                .HasOne(profile => profile.DifficultyLevel)
                .WithMany(estimator => estimator.ApplicationToFactors)
                .HasForeignKey(profile => profile.DifficultyLevelId);

            builder.Property(estimator => estimator.Value)
                    .IsRequired();
        }
    }
}