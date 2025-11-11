namespace CineReview.Data
{
    using Microsoft.EntityFrameworkCore;

    public class CineReviewContext : DbContext
    {
        public CineReviewContext(DbContextOptions<CineReviewContext> options)
            : base(options) { }

        public DbSet<Midia> Midias { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Midia>()
                .HasDiscriminator<string>("TipoMidia")
                .HasValue<Filme>("Filme")
                .HasValue<Serie>("Serie");
        }
    }

}
