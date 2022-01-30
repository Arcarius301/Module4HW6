using Microsoft.EntityFrameworkCore;
using Module4HW6.Data.Entities;
using Module4HW6.Data.EntityConfigurations;

namespace Module4HW6.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Artist> Artist { get; set; } = null!;
        public DbSet<ArtistSong> ArtistSong { get; set; } = null!;
        public DbSet<Genre> Genre { get; set; } = null!;
        public DbSet<Song> Song { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistSongConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
        }
    }
}
