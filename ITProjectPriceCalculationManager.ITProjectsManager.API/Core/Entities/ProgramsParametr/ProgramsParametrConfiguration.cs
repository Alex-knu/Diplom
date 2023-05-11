using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr
{
    internal class ProgramsParametrConfiguration : IEntityTypeConfiguration<ProgramsParametr>
    {
        public void Configure(EntityTypeBuilder<ProgramsParametr> builder)
        {
            builder
                .HasKey(programsParametr => programsParametr.Id);

            builder
                .HasOne(programsParametr => programsParametr.ProgramLanguage)
                .WithMany(programLanguage => programLanguage.ProgramsParametrs)
                .HasForeignKey(programsParametr => programsParametr.ProgramLanguageId);
        }
    }
}