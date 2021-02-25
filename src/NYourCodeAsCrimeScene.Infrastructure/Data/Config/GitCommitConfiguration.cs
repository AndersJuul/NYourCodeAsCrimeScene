using NYourCodeAsCrimeScene.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NYourCodeAsCrimeScene.Infrastructure.Data.Config
{
    public class GitCommitConfiguration : IEntityTypeConfiguration<GitCommit>
    {
        public void Configure(EntityTypeBuilder<GitCommit> builder)
        {
            builder
                .Property(t => t.Project)
                .IsRequired()
                .HasColumnName("ProjectId");
        }
    }
}
