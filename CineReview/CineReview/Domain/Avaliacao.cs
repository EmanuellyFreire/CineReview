using CineReview.Application.Service;
using System.Text.Json.Serialization;

namespace CineReview.Domain
{
    public class Avaliacao
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }

        public int MidiaId { get; set; }
        public Midia? Midia { get; set; }

        public int Nota { get; set; } // 0 a 10
        public string? Comentario { get; set; }

        public Avaliacao()
        {
            Comentario = "";
        }
    }

}
