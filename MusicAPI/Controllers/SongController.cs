using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using MusicAPI.Models;

namespace MusicAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly APIDbContext _context;

        public SongController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongModel>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongModel>> GetSongModel(int id)
        {
            var songModel = await _context.Songs.FindAsync(id);

            if (songModel == null)
            {
                return NotFound();
            }

            return songModel;
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongModel(int id, SongModel songModel)
        {
            if (id != songModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(songModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongModel>> PostSongModel(SongModel songModel)
        {
            _context.Songs.Add(songModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSongModel), new { id = songModel.Id }, songModel);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongModel(int id)
        {
            var songModel = await _context.Songs.FindAsync(id);
            if (songModel == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongModelExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
