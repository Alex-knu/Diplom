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

            builder.HasData(
                new ProgramLanguage { Id = 1, Name = "ABAP (SAP)", SLOC = 28 },
                new ProgramLanguage { Id = 2, Name = "ASP", SLOC = 51 },
                new ProgramLanguage { Id = 3, Name = "Assembler", SLOC = 119 },
                new ProgramLanguage { Id = 4, Name = "Brio +", SLOC = 14 },
                new ProgramLanguage { Id = 5, Name = "C", SLOC = 97 },
                new ProgramLanguage { Id = 6, Name = "C++", SLOC = 50 },
                new ProgramLanguage { Id = 7, Name = "C#", SLOC = 54 },
                new ProgramLanguage { Id = 8, Name = "COBOL", SLOC = 61 },
                new ProgramLanguage { Id = 9, Name = "Cognos Impromptu Scripts +", SLOC = 47 },
                new ProgramLanguage { Id = 10, Name = "Cross System Products (CSP) +", SLOC = 20 },
                new ProgramLanguage { Id = 11, Name = "Cool:Gen/IEF", SLOC = 32 },
                new ProgramLanguage { Id = 12, Name = "Datastage", SLOC = 71 },
                new ProgramLanguage { Id = 13, Name = "Excel", SLOC = 209 },
                new ProgramLanguage { Id = 14, Name = "Focus", SLOC = 43 },
                new ProgramLanguage { Id = 15, Name = "FoxPro", SLOC = 36 },
                new ProgramLanguage { Id = 16, Name = "HTML", SLOC = 34 },
                new ProgramLanguage { Id = 17, Name = "J2EE", SLOC = 46 },
                new ProgramLanguage { Id = 18, Name = "Java", SLOC = 53 },
                new ProgramLanguage { Id = 19, Name = "JavaScript", SLOC = 47 },
                new ProgramLanguage { Id = 20, Name = "JCL", SLOC = 62 },
                new ProgramLanguage { Id = 21, Name = "LINC II", SLOC = 29 },
                new ProgramLanguage { Id = 22, Name = "Lotus Notes", SLOC = 23 },
                new ProgramLanguage { Id = 23, Name = "Natural", SLOC = 40 },
                new ProgramLanguage { Id = 24, Name = ".NET", SLOC = 57 },
                new ProgramLanguage { Id = 25, Name = "Oracle", SLOC = 37 }
            );
        }
    }
}