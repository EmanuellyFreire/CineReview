using CineReview.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        //// GET: api/<SerieController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<SerieController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SerieController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SerieController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SerieController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        private readonly CineReviewContext _context;

        public SerieController(CineReviewContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serie>>> GetSeries()
        {
            return await _context.Series.ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);

            if (serie == null)
                return NotFound();

            return serie;
        }

        // POST: api/Series
        [HttpPost]
        public async Task<ActionResult<Serie>> PostSerie(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSerie), new { id = serie.Id }, serie);
        }

        // PUT: api/Series/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie(int id, Serie serie)
        {
            if (id != serie.Id)
                return BadRequest();

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
                return NotFound();

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return Ok("Série removida com sucesso");
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
