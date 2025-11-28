using CineReview.Domain;
using CineReview.Infrastructure.Data;

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

        _context.Avaliacoes.Add(aval);
        await _context.SaveChangesAsync();

        return aval;
    }
}
