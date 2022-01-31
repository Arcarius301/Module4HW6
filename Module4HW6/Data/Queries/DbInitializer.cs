using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.Queries
{
    public class DbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddData()
        {
            var genres = new List<Genre>
            {
                new Genre { Title = "Post-punk" },
                new Genre { Title = "Pop" },
                new Genre { Title = "Rap" },
                new Genre { Title = "Drum and Bass" },
                new Genre { Title = "House" }
            };

            var artists = new List<Artist>
            {
                new Artist { Name = "Jean-Jacques Burnel", DateOfBirth = new DateTime(1952, 2, 21) },
                new Artist { Name = "Waltraut Hugo Weiner", DateOfBirth = new DateTime(1978, 5, 20) },
                new Artist { Name = "Jost Kerstin Hall", DateOfBirth = new DateTime(2002, 1, 1) },
                new Artist { Name = "Vano Aleksandre Beridze", DateOfBirth = new DateTime(1995, 6, 12) },
                new Artist { Name = "Goga Adam Beridze", DateOfBirth = new DateTime(1985, 11, 2) }
            };

            var songs = new List<Song>
            {
                new Song { Title = "Title1", Duration = "02:25", ReleasedDate = new DateTime(1970, 3, 15), GenreId = 1 },
                new Song { Title = "Title2", Duration = "03:25", ReleasedDate = new DateTime(2011, 5, 17), GenreId = 1 },
                new Song { Title = "Title3", Duration = "02:32", ReleasedDate = new DateTime(1980, 1, 11), GenreId = 2 },
                new Song { Title = "Title4", Duration = "02:11", ReleasedDate = new DateTime(1970, 7, 1), GenreId = 3 },
                new Song { Title = "Title5", Duration = "01:57", ReleasedDate = new DateTime(2020, 2, 25), GenreId = 4 },
                new Song { Title = "Title6", Duration = "01:57", ReleasedDate = new DateTime(1995, 2, 25), GenreId = 4 },
                new Song { Title = "Title7", Duration = "01:57", ReleasedDate = new DateTime(2020, 2, 25), GenreId = 5 },
                new Song { Title = "Title8", Duration = "01:57", ReleasedDate = new DateTime(2012, 2, 25), GenreId = 5 },
            };

            var artistsong = new List<ArtistSong>
            {
                new ArtistSong { ArtistId = 1, SongId = 1 },
                new ArtistSong { ArtistId = 2, SongId = 2 },
                new ArtistSong { ArtistId = 3, SongId = 3 },
                new ArtistSong { ArtistId = 4, SongId = 4 },
                new ArtistSong { ArtistId = 5, SongId = 5 },
                new ArtistSong { ArtistId = 1, SongId = 6 },
                new ArtistSong { ArtistId = 1, SongId = 8 },
            };

            if (!_context.Genre.Any())
            {
                await _context.AddRangeAsync(genres);
            }

            if (!_context.Artist.Any())
            {
                await _context.AddRangeAsync(artists);
            }

            if (!_context.Song.Any())
            {
                await _context.AddRangeAsync(songs);
            }

            await _context.SaveChangesAsync();

            if (!_context.ArtistSong.Any())
            {
                await _context.AddRangeAsync(artistsong);
            }

            await _context.SaveChangesAsync();
        }
    }
}
