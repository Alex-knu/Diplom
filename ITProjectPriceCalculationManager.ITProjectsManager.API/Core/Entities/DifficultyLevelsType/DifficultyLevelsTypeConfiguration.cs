using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsType
{
    internal class DifficultyLevelsTypeConfiguration : IEntityTypeConfiguration<DifficultyLevelsType>
    {
        public void Configure(EntityTypeBuilder<DifficultyLevelsType> builder)
        {
            builder.HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();

            builder.HasData(
                new DifficultyLevelsType { Id = 1, Name = "Super low" },
                new DifficultyLevelsType { Id = 2, Name = "Very low" },
                new DifficultyLevelsType { Id = 3, Name = "Low" },
                new DifficultyLevelsType { Id = 4, Name = "Normal" },
                new DifficultyLevelsType { Id = 5, Name = "Medium" },
                new DifficultyLevelsType { Id = 6, Name = "High" },
                new DifficultyLevelsType { Id = 7, Name = "Super high" },
                new DifficultyLevelsType { Id = 8, Name = "Very high" }
            );
        }
    }
}