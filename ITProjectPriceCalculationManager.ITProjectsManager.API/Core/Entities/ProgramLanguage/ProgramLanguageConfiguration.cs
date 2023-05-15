using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage
{
    internal class ProgramLanguageConfiguration : IEntityTypeConfiguration<ProgramLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgramLanguage> builder)
        {
            builder.HasKey(programLanguage => programLanguage.Id);

            builder.Property(programLanguage => programLanguage.Name)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(programLanguage => programLanguage.SLOC)
                   .IsRequired();
        }
    }
}