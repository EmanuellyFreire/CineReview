using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CineReview.Application.Service
{
    public class MidiaService
    {
        private readonly CineReviewContext _context;

        public MidiaService(CineReviewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Midia>> GetAllAsync()
        {
            return await _context.Midias.ToListAsync();
        }

        public async Task<Midia?> GetByIdAsync(int id)
        {
            return await _context.Midias.FindAsync(id);
        }

        public async Task<IEnumerable<Midia>> BuscarPorTituloAsync(string termo)
        {
            return await _context.Midias
                .Where(m => m.Titulo.Contains(termo))
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var midia = await _context.Midias.FindAsync(id);
            if (midia == null) return false;

            _context.Midias.Remove(midia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
