using Microsoft.AspNetCore.Mvc;
using CineReview.Domain;
using CineReview.Application.Service;

namespace CineReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _service;

        public FilmeController(FilmeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmes()
            => Ok(await _service.ListarFilmes());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilme(int id)
        {
            var filme = await _service.BuscarPorId(id);
            return filme == null ? NotFound() : Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> PostFilme(Filme filme)
        {
            var criado = await _service.Criar(filme);
            return CreatedAtAction(nameof(GetFilme), new { id = criado.Id }, criado);
        }

        [HttpGet("ranking")]
        public async Task<IActionResult> Ranking()
            => Ok(await _service.Ranking());

        [HttpGet("buscar")]
        public async Task<IActionResult> Buscar(string termo)
            => Ok(await _service.Buscar(termo));

        [HttpGet("teste/{id}")]
        public async Task<IActionResult> TestarTmdb(int id)
        {
            var filme = await _service.EncontrarFilmeDoTmdb(id);
            return filme == null ? NotFound() : Ok(filme);
        }
    }
}
