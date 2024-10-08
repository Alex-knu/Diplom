using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParameter;

internal class EvaluateParameterConfiguration : IEntityTypeConfiguration<EvaluateParameter>
{
    public void Configure(EntityTypeBuilder<EvaluateParameter> builder)
    {
        builder.HasKey(ep => ep.Id);

        builder.Property(ep => ep.Name)
            .IsRequired();

        builder.Property(ep => ep.BelongingFunctionId)
            .IsRequired();

        builder.Property(ep => ep.ParameterId)
            .IsRequired();
        
        builder
            .HasOne(p => p.EvaluateParameterValue)
            .WithOne(pv => pv.EvaluateParameter)
            .HasForeignKey<ParameterValue.ParameterValue>(pv => pv.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(ep => ep.BelongingFunction)
            .WithMany(bf => bf.EvaluateParameters)
            .HasForeignKey(ep => ep.BelongingFunctionId);
    }
}