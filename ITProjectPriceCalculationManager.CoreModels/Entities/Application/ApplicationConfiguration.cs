using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.CoreModels.Entities.Application
{
    public class ApplicationConfiguration: IEntityTypeConfiguration<Application>
    {
       public void Configure(EntityTypeBuilder<Application> builder)
       {
              builder
                     .HasKey(application => application.Id);

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

              builder
                     .HasMany(application => application.ProgramsParametrs)
                     .WithOne(programParametr => programParametr.Application)
                     .HasForeignKey(programsParametr => programsParametr.ApplicationId);           
       }
    }
}