using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.Core.Entities.ProgramsParametrToSubjectAreaElement
{
    public class ProgramsParametrToSubjectAreaElementConfiguration : IEntityTypeConfiguration<ProgramsParametrToSubjectAreaElement>
    {
        public void Configure(EntityTypeBuilder<ProgramsParametrToSubjectAreaElement> builder)
        {
            builder
                .HasKey(programsParametrToSubjectAreaElement => programsParametrToSubjectAreaElement.Id);

            builder
                .HasOne(programsParametrToSubjectAreaElement => programsParametrToSubjectAreaElement.ProgramsParametr)
                .WithMany(programsParametr => programsParametr.ProgramsParametrToSubjectAreaElements)
                .HasForeignKey(programsParametrToSubjectAreaElement => programsParametrToSubjectAreaElement.ProgramsParametrId);

            builder
                .HasOne(programsParametrToSubjectAreaElement => programsParametrToSubjectAreaElement.SubjectAreaElement)
                .WithMany(subjectAreaElements => subjectAreaElements.ProgramsParametrToSubjectAreaElements)
                .HasForeignKey(programsParametrToSubjectAreaElement => programsParametrToSubjectAreaElement.SubjectAreaElementId);
        }
    }
}