using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Engine.Storage.Entities.Configurations;

internal sealed class FeedSettingsCfg : IEntityTypeConfiguration<FeedSettings>
{
    public void Configure(EntityTypeBuilder<FeedSettings> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Source)
            .HasConversion<string>();
    }
}