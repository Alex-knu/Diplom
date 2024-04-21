using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameterValue
{
    internal class EvaluateParameterValueConfiguration : IEntityTypeConfiguration<EvaluateParameterValue>
    {
        public void Configure(EntityTypeBuilder<EvaluateParameterValue> builder)
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
}