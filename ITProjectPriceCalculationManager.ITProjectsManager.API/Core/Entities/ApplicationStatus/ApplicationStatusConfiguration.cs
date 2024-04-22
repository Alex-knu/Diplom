using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationStatus;

internal class ApplicationStatusConfiguration : IEntityTypeConfiguration<ApplicationStatus>
{
    public void Configure(EntityTypeBuilder<ApplicationStatus> builder)
    {
        builder.HasKey(application => application.Id);

        builder.Property(application => application.Name)
            .IsRequired();
    }
}