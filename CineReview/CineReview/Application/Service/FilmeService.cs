using CineReview.Application.DTOs;
using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CineReview.Application.Service
{
    public class FilmeService
    {
        private readonly TmdbService _tmdb;
        private readonly CineReviewContext _context;

        public FilmeService(TmdbService tmdb, CineReviewContext context)
        {
            _tmdb = tmdb;
            _context = context;
        }

        public async Task<Filme> CriarFilmeDoTmdb(int id)
        {
            var externo = await _tmdb.BuscarFilme(id);

            var filme = new Filme
            {
                Titulo = externo.title,
                Sinopse = externo.overview,
                Lancamento = DateTime.Parse(externo.release_date),
                Genero = externo.genres?.FirstOrDefault()?.name ?? "Desconhecido",
                DuracaoMinutos = externo.runtime
            };

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return filme;
        }

        public async Task<object> EncontrarFilmeDoTmdb(int id)
        {
            return await _tmdb.BuscarFilme(id);
        }

        public async Task<List<Filme>> ListarFilmes()
            => await _context.Filmes.ToListAsync();

        public async Task<Filme?> BuscarPorId(int id)
            => await _context.Filmes.FindAsync(id);

        public async Task<Filme> Criar(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<object> Ranking()
        {
            return await _context.Avaliacoes
                .GroupBy(a => a.MidiaId)
                .Select(g => new {
                    MidiaId = g.Key,
                    NotaMedia = g.Average(x => x.Nota)
                })
                .OrderByDescending(x => x.NotaMedia)
                .ToListAsync();
        }

        public async Task<List<Filme>> Buscar(string termo)
        {
            return await _context.Filmes
                .Where(f => f.Titulo.Contains(termo))
                .ToListAsync();
        }
    }
}
