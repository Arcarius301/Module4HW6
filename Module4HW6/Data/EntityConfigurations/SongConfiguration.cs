using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("SongId").ValueGeneratedOnAdd();
            builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Duration).IsRequired().HasMaxLength(5);
            builder.Property(s => s.ReleasedDate).HasColumnType("date");

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
