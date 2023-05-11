using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType
{
    internal class FactorTypeConfiguration : IEntityTypeConfiguration<FactorType>
    {
        public void Configure(EntityTypeBuilder<FactorType> builder)
        {
            builder
                   .HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();
        }
    }
}