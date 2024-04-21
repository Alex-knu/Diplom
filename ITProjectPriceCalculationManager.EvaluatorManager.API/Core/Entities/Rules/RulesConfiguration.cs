using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Rules
{
    internal class RulesConfiguration : IEntityTypeConfiguration<Rules>
    {
        public void Configure(EntityTypeBuilder<Rules> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.IfParameterId)
                   .IsRequired();
            builder.Property(p => p.IfValueId)
                   .IsRequired();

            builder.Property(p => p.ThenParameterId)
                   .IsRequired();
            builder.Property(p => p.ThenValueId)
                   .IsRequired();
        }
    }
}