using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CineReview.Application.Service
{
    public class SerieService
    {
        private readonly CineReviewContext _context;

        public SerieService(CineReviewContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Serie?> GetByIdAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task<Serie> CreateAsync(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();
            return serie;
        }

        public async Task<Serie?> UpdateAsync(int id, Serie serie)
        {
            var existing = await GetByIdAsync(id);
            if (existing == null) return null;

            existing.Titulo = serie.Titulo;
            existing.Sinopse = serie.Sinopse;
            existing.Genero = serie.Genero;
            existing.Temporadas = serie.Temporadas;
            existing.Episodios = serie.Episodios;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var serie = await GetByIdAsync(id);
            if (serie == null) return false;

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
