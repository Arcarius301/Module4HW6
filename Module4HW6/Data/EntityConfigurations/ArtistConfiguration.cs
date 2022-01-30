using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("ArtistId").ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(150);
            builder.Property(a => a.DateOfBirth).IsRequired().HasColumnType("date");
            builder.Property(a => a.Phone).HasMaxLength(50);
            builder.Property(a => a.Email).HasMaxLength(50);
            builder.Property(a => a.InstagramUrl).HasMaxLength(50);
        }
    }
}
