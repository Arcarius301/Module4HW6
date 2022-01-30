namespace Module4HW6.Data.Entities
{
    public class ArtistSong
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } = null!;
        public int SongId { get; set; }
        public Song Song { get; set; } = null!;
    }
}
