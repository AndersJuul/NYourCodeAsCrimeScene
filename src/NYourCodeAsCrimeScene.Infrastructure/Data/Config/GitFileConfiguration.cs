using NYourCodeAsCrimeScene.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NYourCodeAsCrimeScene.Infrastructure.Data.Config
{
    public class GitFileConfiguration : IEntityTypeConfiguration<GitFile>
    {
        public void Configure(EntityTypeBuilder<GitFile> builder)
        {
            builder
                .Property(t => t.Name)
                .IsRequired();
            builder.HasMany(x => x.GitFileEntries)
                .WithOne(x=>x.GitFile);
            builder
                .HasIndex(x=> new {x.Name, x.GitCommitId})
                .IsUnique();
        }
    }
}
