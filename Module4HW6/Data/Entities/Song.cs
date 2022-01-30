namespace Module4HW6.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public DateTime ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
