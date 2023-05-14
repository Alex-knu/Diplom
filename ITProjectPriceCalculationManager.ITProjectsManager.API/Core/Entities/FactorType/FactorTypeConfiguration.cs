using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.FactorType
{
    internal class FactorTypeConfiguration : IEntityTypeConfiguration<FactorType>
    {
        public void Configure(EntityTypeBuilder<FactorType> builder)
        {
            builder.HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();

            builder.HasData(
                new FactorType { Id = 1, Name = "Influence factor" },
                new FactorType { Id = 2, Name = "Scale factor" },
                new FactorType { Id = 3, Name = "Internal logical object" },
                new FactorType { Id = 4, Name = "External interface object" },
                new FactorType { Id = 5, Name = "Information object" },
                new FactorType { Id = 6, Name = "Function" }
            );
        }
    }
}