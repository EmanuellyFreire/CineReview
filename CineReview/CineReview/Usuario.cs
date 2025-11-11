namespace CineReview
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; }
        public ICollection<Favorito> Favoritos { get; set; }
    }

}
