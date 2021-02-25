using NYourCodeAsCrimeScene.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NYourCodeAsCrimeScene.Infrastructure.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(t => t.Name)
                .IsRequired();
            builder
                .HasIndex(x=>x.Name)
                .IsUnique();
        }
    }
}
