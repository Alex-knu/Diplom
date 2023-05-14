using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute
{
    internal class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();

            builder.HasData(
                new Attribute { Id = 1, Name = "Qualifications(PERS)" },
                new Attribute { Id = 2, Name = "Experience(PREX)" },
                new Attribute { Id = 3, Name = "Technical support(FCIL)" },
                new Attribute { Id = 4, Name = "Schedule restrictions(SCED)" },
                new Attribute { Id = 5, Name = "Complexity of the program environment(PDIF)" },
                new Attribute { Id = 6, Name = "Complexity and reliability(RCPX)" },
                new Attribute { Id = 7, Name = "Reuse requested(RUSE)" },
                new Attribute { Id = 8, Name = "Product novelty for the developer's company(PREC)" },
                new Attribute { Id = 9, Name = "Development flexibility(FLEX)" },
                new Attribute { Id = 10, Name = "Level of risk/architecture management (%)(RESL)" },
                new Attribute { Id = 11, Name = "Cohesion of the development team(TEAM)" },
                new Attribute { Id = 12, Name = "Technology maturity maturity process development(PMAT)" },
                new Attribute { Id = 13, Name = "Internal logical object" },
                new Attribute { Id = 14, Name = "External interface object" }
            );
        }
    }
}