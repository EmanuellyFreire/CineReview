using System.Text.Json.Serialization;

namespace CineReview.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [JsonIgnore]
        public ICollection<Avaliacao> Avaliacoes { get; set; }

        [JsonIgnore]
        public ICollection<Favorito> Favoritos { get; set; }

        public Usuario()
        {
            Avaliacoes = new List<Avaliacao>();
            Favoritos = new List<Favorito>();
        }
    }

}
