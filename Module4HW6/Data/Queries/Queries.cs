using Microsoft.EntityFrameworkCore;
using Module4HW6.Data.Entities;

namespace Module4HW6.Data.Queries
{
    public class Queries
    {
        private readonly ApplicationContext _context;

        public Queries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task ShowSongs()
        {
            var data = await _context.Song
                .Include(e => e.Genre)
                .Include(e => e.ArtistSong)
                .ThenInclude(e => e.Artist)
                .Select(s => new
                {
                    SongName = s.Title,
                    GenreName = s.Genre.Title,
                    Artists = s.ArtistSong
                })
                .Where(e => e.Artists.Any())
                .ToListAsync();

            if (data.Any())
            {
                Console.WriteLine("====================");
                Console.WriteLine("Songs:\n--------------------");
                foreach (var item in data)
                {
                    Console.WriteLine($"Song: {item.SongName}, Genre: {item.GenreName}, \nArtist: ");
                    foreach (var artist in item.Artists)
                    {
                        Console.WriteLine($"{artist.Artist.Name}");
                    }

                    Console.WriteLine("--------------------");
                }
            }
        }

        public async Task ShowGroupedByGenre()
        {
            var data = await _context.Song
                .Include(e => e.Genre)
                .GroupBy(g => g.Genre.Title)
                .Select(s => new
                {
                    GenreName = s.Key,
                    Count = s.Count()
                })
                .ToListAsync();

            if (data.Any())
            {
                Console.WriteLine("====================");
                Console.WriteLine("Genre - Count:\n--------------------");
                foreach (var item in data)
                {
                    Console.WriteLine($"Genre: {item.GenreName}, Count: {item.Count}");
                    Console.WriteLine("--------------------");
                }
            }
        }

        public async Task ShowFilteredSongs()
        {
            var maxDate = await _context.Artist
                .MaxAsync(e => e.DateOfBirth);

            var data = await _context.Song
                .Where(e => e.ReleasedDate < maxDate)
                .ToListAsync();

            if (data.Any())
            {
                Console.WriteLine("====================");
                Console.WriteLine($"Songs before {maxDate:yyyy/MM/dd}:\n--------------------");
                foreach (var item in data)
                {
                    Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, ReleasedDate: {item.ReleasedDate:yyyy/MM/dd}, Duration: {item.Duration}");
                    Console.WriteLine("--------------------");
                }
            }
        }
    }
}
