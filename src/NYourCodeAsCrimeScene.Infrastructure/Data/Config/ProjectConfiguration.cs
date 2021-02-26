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
            builder
                .HasMany(x => x.Commits)
                .WithOne(x => x.Project)
                .HasForeignKey(x=>x.ProjectId)
                .IsRequired();
        }
    }
}
