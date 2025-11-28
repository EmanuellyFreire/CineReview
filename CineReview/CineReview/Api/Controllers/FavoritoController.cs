using CineReview.Application.Service;
using CineReview.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CineReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        private readonly FavoritoService _service;

        public FavoritoController(FavoritoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(Favorito fav)
        {
            try
            {
                var criado = await _service.AdicionarAsync(fav);
                return Ok(criado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> Listar(int usuarioId)
        {
            var lista = await _service.ListarPorUsuarioAsync(usuarioId);
            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var ok = await _service.RemoverAsync(id);
            return ok ? Ok("Removido") : NotFound();
        }
    }
}
