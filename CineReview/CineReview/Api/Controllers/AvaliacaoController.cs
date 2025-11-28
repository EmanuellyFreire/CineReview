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
}
