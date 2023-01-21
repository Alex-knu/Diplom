using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement
{
    internal class SubjectAreaElementConfiguration  : IEntityTypeConfiguration<SubjectAreaElement>
    {
        public void Configure(EntityTypeBuilder<SubjectAreaElement> builder)
        {
            builder
                .HasKey(subjectAreaElement => subjectAreaElement.Id);

            builder.Property(subjectAreaElement => subjectAreaElement.SubjectAreaType)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(subjectAreaElement => subjectAreaElement.DifficultyLevelsType)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(subjectAreaElement => subjectAreaElement.Count)
                   .IsRequired();
        }
    }
}