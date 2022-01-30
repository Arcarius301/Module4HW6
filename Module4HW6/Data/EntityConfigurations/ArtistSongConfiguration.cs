using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.EntityConfigurations
{
    internal class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong").HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ArtistSongId").ValueGeneratedOnAdd();

            builder.HasOne(e => e.Artist)
                .WithMany(a => a.ArtistSong)
                .HasForeignKey(e => e.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Song)
                .WithMany(s => s.ArtistSong)
                .HasForeignKey(e => e.SongId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
