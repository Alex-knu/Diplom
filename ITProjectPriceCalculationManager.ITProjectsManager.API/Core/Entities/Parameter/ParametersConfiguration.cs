using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Parameter;

internal class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
{
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder
            .HasOne(applicationToEvaluators => applicationToEvaluators.Application)
            .WithMany(application => application.ApplicationToParameters)
            .HasForeignKey(applicationToEvaluators => applicationToEvaluators.ApplicationId);

        builder
            .HasMany(parameter => parameter.EvaluateParameters)
            .WithOne(evaluateParameter => evaluateParameter.Parameter)
            .HasForeignKey(evaluateParameter => evaluateParameter.ParameterId);
    }
}