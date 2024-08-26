using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.BelongingFunction;

internal class BelongingFunctionConfiguration : IEntityTypeConfiguration<BelongingFunction>
{
    public void Configure(EntityTypeBuilder<BelongingFunction> builder)
    {
        builder.HasKey(bf => bf.Id);

        builder.Property(bf => bf.Name)
            .IsRequired();
    }
}