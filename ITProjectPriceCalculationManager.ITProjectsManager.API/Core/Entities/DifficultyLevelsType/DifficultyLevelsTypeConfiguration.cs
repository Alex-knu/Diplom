using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType
{
    internal class DifficultyLevelsTypeConfiguration : IEntityTypeConfiguration<DifficultyLevelsType>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevelsType> builder)
        {
            builder
                   .HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();
        }
    }
}