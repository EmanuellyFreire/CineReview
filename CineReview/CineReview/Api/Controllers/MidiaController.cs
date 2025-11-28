using CineReview.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CineReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidiaController : ControllerBase
    {
        private readonly MidiaService _service;

        public MidiaController(MidiaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var midia = await _service.GetByIdAsync(id);
            if (midia == null) return NotFound();

            return Ok(midia);
        }

        [HttpGet("buscar/{termo}")]
        public async Task<IActionResult> Buscar(string termo)
        {
            var resultado = await _service.BuscarPorTituloAsync(termo);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok("Mídia removida com sucesso");
        }
    }
}
