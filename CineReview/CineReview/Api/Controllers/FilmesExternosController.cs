using Microsoft.AspNetCore.Mvc;
using CineReview.Application.Service;

[ApiController]
[Route("api/[controller]")]
public class FilmesExternosController : ControllerBase
{
    private readonly FilmeService _service;

    public FilmesExternosController(FilmeService service)
    {
        _service = service;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> ImportarFilme(int id)
    {
        var filme = await _service.CriarFilmeDoTmdb(id);
        return Ok(filme);
    }
}
