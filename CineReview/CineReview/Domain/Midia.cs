using System.Text.Json.Serialization;

namespace CineReview.Domain
{
    public abstract class Midia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Sinopse { get; set; }
        public string? Genero { get; set; }
        public DateTime Lancamento { get; set; }

        [JsonIgnore]
        public ICollection<Avaliacao> Avaliacoes { get; set; }

        [JsonIgnore]
        public ICollection<Favorito> Favoritos { get; set; }

        public Midia()
        {
            Avaliacoes = new List<Avaliacao>();
            Favoritos = new List<Favorito>();

            Sinopse = "";
            Genero = "";
        }
    }


}
