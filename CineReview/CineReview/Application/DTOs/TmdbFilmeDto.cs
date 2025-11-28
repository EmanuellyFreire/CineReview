namespace CineReview.Application.DTOs
{
    public class TmdbFilmeDto
    {
        public string title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int runtime { get; set; }
        public List<GeneroDto> genres { get; set; }
    }

    public class GeneroDto
    {
        public string name { get; set; }
    }
}
