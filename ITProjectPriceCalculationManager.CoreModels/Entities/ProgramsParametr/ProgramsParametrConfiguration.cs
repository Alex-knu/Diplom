using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.CoreModels.Entities.ProgramsParametr
{
    public class ProgramsParametrConfiguration : IEntityTypeConfiguration<ProgramsParametr>
    {
        public void Configure(EntityTypeBuilder<ProgramsParametr> builder)
        {
            builder
                .HasKey(programsParametr => programsParametr.Id);

            builder.Property(programsParametr => programsParametr.SLOC)
                   .IsRequired();

            builder
                .HasOne(programsParametr => programsParametr.ProgramLanguage)
                .WithMany(programLanguage => programLanguage.ProgramsParametrs)
                .HasForeignKey(programsParametr => programsParametr.ProgramLanguageId);
        }
    }
}