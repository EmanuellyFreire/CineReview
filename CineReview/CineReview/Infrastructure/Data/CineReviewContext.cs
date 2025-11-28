namespace CineReview.Infrastructure.Data
{
    using CineReview.Domain;
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
            base.OnModelCreating(modelBuilder);

            // 🔹 Herança 
            modelBuilder.Entity<Midia>()
                .HasDiscriminator<string>("TipoMidia")
                .HasValue<Filme>("Filme")
                .HasValue<Serie>("Serie");

            // 🔹 Usuário -> Avaliações (1:N)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Avaliacoes)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Usuário -> Favoritos (1:N)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Favoritos)
                .WithOne(f => f.Usuario)
                .HasForeignKey(f => f.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Midia -> Avaliações (1:N)
            modelBuilder.Entity<Midia>()
                .HasMany(m => m.Avaliacoes)
                .WithOne(a => a.Midia)
                .HasForeignKey(a => a.MidiaId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Midia -> Favoritos (1:N)
            modelBuilder.Entity<Midia>()
                .HasMany(m => m.Favoritos)
                .WithOne(f => f.Midia)
                .HasForeignKey(f => f.MidiaId)
                .OnDelete(DeleteBehavior.Cascade);

            // (Opcional) Criar índices para melhorar buscas
            modelBuilder.Entity<Midia>()
                .HasIndex(m => m.Titulo);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Favorito>()
                .HasKey(f => f.Id);


            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Favoritos)
                .HasForeignKey(f => f.UsuarioId);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Midia)
                .WithMany(m => m.Favoritos)
                .HasForeignKey(f => f.MidiaId);

        }

    }

}
