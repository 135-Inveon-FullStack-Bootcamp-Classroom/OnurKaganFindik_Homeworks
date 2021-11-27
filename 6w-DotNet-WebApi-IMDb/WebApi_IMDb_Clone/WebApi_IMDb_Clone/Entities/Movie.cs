namespace WebApi_IMDb_Clone.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string DirectorFullName { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
    }
}
