namespace Module4HW6.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public DateOnly ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
