using NYourCodeAsCrimeScene.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NYourCodeAsCrimeScene.Infrastructure.Data.Config
{
    public class GitFileEntryConfiguration : IEntityTypeConfiguration<GitFileEntry>
    {
        public void Configure(EntityTypeBuilder<GitFileEntry> builder)
        {
            builder
                .Property(t => t.FileLength)
                .IsRequired();
        }
    }
}
