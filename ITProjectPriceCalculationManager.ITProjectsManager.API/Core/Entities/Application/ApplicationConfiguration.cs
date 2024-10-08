using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;

internal class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(application => application.Id);

        builder.Property(application => application.Price)
            .IsRequired();

        builder.Property(application => application.Profit)
            .IsRequired();

        builder.Property(application => application.Overhead)
            .IsRequired();

        builder.Property(application => application.SocialInsurance)
            .IsRequired();

        builder.Property(application => application.AverageCostLabor)
            .IsRequired();

        builder.Property(application => application.AverageMonthlyRateWorkingHours)
            .IsRequired();

        builder.Property(application => application.Name)
            .IsRequired();

        builder.Property(application => application.Description)
            .IsRequired();

        builder.Property(application => application.ConfidenceArea);

        builder
            .HasOne(application => application.Creator)
            .WithMany(estimator => estimator.Applications)
            .HasForeignKey(programsParametr => programsParametr.CreatorId);


        builder
            .HasOne(application => application.Status)
            .WithMany(statuses => statuses.Applications)
            .HasForeignKey(application => application.StatusId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}