using System.Text.Json.Serialization;

namespace CineReview.Domain
{
    public class Favorito
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        public int MidiaId { get; set; }
        public Midia? Midia { get; set; }
    }

}
