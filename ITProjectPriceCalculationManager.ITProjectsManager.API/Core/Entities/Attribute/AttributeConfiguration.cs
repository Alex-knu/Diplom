using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute
{
    internal class AttributeConfiguration : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder
                   .HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.Name)
                   .IsRequired();
        }
    }
}