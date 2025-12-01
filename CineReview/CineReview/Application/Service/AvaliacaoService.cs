using CineReview.Domain;
using CineReview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AvaliacaoService
{
    private readonly CineReviewContext _context;

    public AvaliacaoService(CineReviewContext context)
    {
        _context = context;
    }

    public async Task<Avaliacao> CriarAsync(Avaliacao aval)
    {
        if (aval.Nota < 0 || aval.Nota > 10)
            throw new ArgumentOutOfRangeException(nameof(aval.Nota), "Nota deve ser entre 0 e 10");

        // Verifica se usuário existe
        var usuario = await _context.Usuarios.FindAsync(aval.UsuarioId);
        if (usuario == null)
            throw new Exception("Usuário não encontrado");

        // Verifica se a mídia existe
        var midia = await _context.Midias.FindAsync(aval.MidiaId);
        if (midia == null)
            throw new Exception("Mídia não encontrada");

        aval.Midia = midia;
        aval.Usuario = usuario;

        _context.Avaliacoes.Add(aval);
        await _context.SaveChangesAsync();

        await _context.SaveChangesAsync();

        return await _context.Avaliacoes
            .Include(a => a.Usuario)
            .Include(a => a.Midia)
            .FirstAsync(a => a.Id == aval.Id);
    }

    public async Task<Avaliacao?> BuscarPorIdAsync(int id)
    {
        return await _context.Avaliacoes
            .Include(a => a.Midia)
            .Include(a => a.Usuario)
            .FirstOrDefaultAsync(a => a.Id == id);
    }


    public async Task<IEnumerable<Avaliacao>> ListarPorMidiaAsync(int midiaId)
    {
        return await _context.Avaliacoes
            .Include(a => a.Usuario)
            .Include(a => a.Midia)
            .Where(a => a.MidiaId == midiaId)
            .ToListAsync();

    }

    public async Task<IEnumerable<Avaliacao>> ListarPorUsuarioAsync(int usuarioId)
    {

        return await _context.Avaliacoes
            .Include(a => a.Usuario)
            .Include(a => a.Midia)
            .Where(a => a.UsuarioId == usuarioId)
            .ToListAsync();

    }

    public async Task<Avaliacao?> AtualizarAsync(int id, Avaliacao data)
    {
        var existing = await _context.Avaliacoes.FindAsync(id);
        if (existing == null)
            return null;

        if (data.Nota < 0 || data.Nota > 10)
            throw new Exception("Nota deve ser entre 0 e 10");

        existing.Nota = data.Nota;
        existing.Comentario = data.Comentario;

        await _context.SaveChangesAsync();
        await _context.SaveChangesAsync();

        return await _context.Avaliacoes
            .Include(a => a.Usuario)
            .Include(a => a.Midia)
            .FirstAsync(a => a.Id == data.Id);
    }



    public async Task<bool> RemoverAsync(int id)
    {
        var aval = await _context.Avaliacoes.FindAsync(id);
        if (aval == null) return false;

        _context.Avaliacoes.Remove(aval);
        await _context.SaveChangesAsync();
        return true;
    }
}
