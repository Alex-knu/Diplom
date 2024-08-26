using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluateParametersToAgents;

internal class EvaluateParametersToAgentsConfiguration : IEntityTypeConfiguration<EvaluateParametersToAgents>
{
    public void Configure(EntityTypeBuilder<EvaluateParametersToAgents> builder)
    {
        builder.HasKey(ep => ep.Id);

        builder.Property(ep => ep.Value)
            .IsRequired();
        
        builder
            .HasOne(epta => epta.Agent)
            .WithOne(e => e.EvaluateParametersToAgent)
            .HasForeignKey<EvaluateParametersToAgents>(epta => epta.AgentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(epta => epta.Parameter)
            .WithOne(p => p.EvaluateParametersToAgent)
            .HasForeignKey<EvaluateParametersToAgents>(epta => epta.ParameterId);
    }
}