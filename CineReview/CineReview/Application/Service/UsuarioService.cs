using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CineReview.Application.Service
{
    public class UsuarioService
    {
        private readonly CineReviewContext _context;

        public UsuarioService(CineReviewContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Avaliacoes)
                .Include(u => u.Favoritos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario usuario)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null) return null;

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
