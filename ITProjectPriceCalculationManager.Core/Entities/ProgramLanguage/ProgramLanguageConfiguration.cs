using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.Core.Entities.ProgramLanguage
{
    public class ProgramLanguageConfiguration : IEntityTypeConfiguration<ProgramLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgramLanguage> builder)
        {
            builder
                .HasKey(programLanguage => programLanguage.Id);

            builder.Property(programLanguage => programLanguage.Name)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(programLanguage => programLanguage.SLOC)
                   .IsRequired();
        }
    }
}