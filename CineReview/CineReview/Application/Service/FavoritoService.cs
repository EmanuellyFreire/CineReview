using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CineReview.Application.Service
{
    public class FavoritoService
    {
        private readonly CineReviewContext _context;

        public FavoritoService(CineReviewContext context)
        {
            _context = context;
        }

        public async Task<Favorito> AdicionarAsync(Favorito fav)
        {
            // Verifica usuário
            var usuario = await _context.Usuarios.FindAsync(fav.UsuarioId);
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            // Verifica mídia
            var midia = await _context.Midias.FindAsync(fav.MidiaId);
            if (midia == null)
                throw new Exception("Mídia não encontrada.");

            // Verifica duplicado
            bool jaExiste = await _context.Favoritos
                .AnyAsync(f => f.UsuarioId == fav.UsuarioId && f.MidiaId == fav.MidiaId);

            if (jaExiste)
                throw new Exception("Esta mídia já está nos favoritos do usuário.");

            _context.Favoritos.Add(fav);
            await _context.SaveChangesAsync();

            return fav;
        }

        public async Task<IEnumerable<Favorito>> ListarPorUsuarioAsync(int usuarioId)
        {
            return await _context.Favoritos
                .Include(f => f.Midia)
                .Where(f => f.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var fav = await _context.Favoritos.FindAsync(id);
            if (fav == null) return false;

            _context.Favoritos.Remove(fav);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
