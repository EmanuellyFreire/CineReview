using CineReview.Domain;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AvaliacaoController : ControllerBase
{
    private readonly AvaliacaoService _service;

    public AvaliacaoController(AvaliacaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Avaliar(Avaliacao aval)
    {
        var criada = await _service.CriarAsync(aval);
        return Ok(criada);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(int id)
    {
        var avaliacao = await _service.BuscarPorIdAsync(id);
        if (avaliacao == null)
            return NotFound("Avaliação não encontrada.");

        return Ok(avaliacao);
    }

    [HttpGet("midia/{midiaId}")]
    public async Task<IActionResult> ListarPorMidia(int midiaId)
    {
        var lista = await _service.ListarPorMidiaAsync(midiaId);
        return Ok(lista);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> ListarPorUsuario(int usuarioId)
    {
        var lista = await _service.ListarPorUsuarioAsync(usuarioId);
        return Ok(lista);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Avaliacao dados)
    {
        try
        {
            var atualizada = await _service.AtualizarAsync(id, dados);
            if (atualizada == null)
                return NotFound("Avaliação não encontrada.");

            return Ok(atualizada);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remover(int id)
    {
        var removida = await _service.RemoverAsync(id);
        return removida ? Ok("Avaliação removida.") : NotFound("Avaliação não encontrada.");


    }


}
