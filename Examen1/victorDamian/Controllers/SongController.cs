using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using victorDamian.Models;
using victorDamian.Repositories;

namespace victorDamian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ContextSong _context;

        public SongController(ContextSong context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAll()
        {
            return await _context.Song.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song != null)
                return Ok(song);
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(Song song)
        {
            _context.Add(song);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSong), new
            {
                ismn = song.Ismn
            }, song);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Song>> UpdateSong(int id, Song song)
        {
            if (id != song.Ismn)
                return BadRequest();
            _context.Update(song);
            await _context.SaveChangesAsync();
            return Ok(song);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(int id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
                return NotFound();
            _context.Remove(song);
            await _context.SaveChangesAsync();
            return Ok(song);
        }
    }
}
