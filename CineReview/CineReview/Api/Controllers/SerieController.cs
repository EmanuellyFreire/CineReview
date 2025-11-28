using CineReview.Application.Service;
using CineReview.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CineReview.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly SerieService _service;

        public SerieController(SerieService service)
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
            var serie = await _service.GetByIdAsync(id);
            if (serie == null) return NotFound();

            return Ok(serie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Serie serie)
        {
            var created = await _service.CreateAsync(serie);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Serie serie)
        {
            if (id != serie.Id)
                return BadRequest("Id da URL e do body não coincidem.");

            var updated = await _service.UpdateAsync(id, serie);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return Ok("Série removida com sucesso");
        }
    }
}
