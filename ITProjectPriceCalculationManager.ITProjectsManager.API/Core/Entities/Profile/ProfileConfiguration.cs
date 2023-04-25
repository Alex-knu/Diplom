using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile
{
    internal class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                   .HasKey(profile => profile.Id);

            builder.Property(profile => profile.Value)
                   .IsRequired();

            builder
                .HasOne(profile => profile.Estimator)
                .WithMany(estimator => estimator.Profiles)
                .HasForeignKey(profile => profile.EstimatorId);

            builder
                .HasOne(profile => profile.Attribute)
                .WithMany(attribute => attribute.Profiles)
                .HasForeignKey(profile => profile.AttributeId);
        }
    }
}