using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

internal class ParameterValueConfiguration : IEntityTypeConfiguration<ParameterValue>
{
    public void Configure(EntityTypeBuilder<ParameterValue> builder)
    {
        builder.HasKey(epv => epv.Id);

        builder.Property(epv => epv.A)
            .IsRequired();
        builder.Property(epv => epv.B)
            .IsRequired();
        builder.Property(epv => epv.C)
            .IsRequired();
        builder.Property(epv => epv.D)
            .IsRequired();
    }
}