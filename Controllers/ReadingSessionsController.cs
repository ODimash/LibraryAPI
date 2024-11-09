using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingSessionsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReadingSessionsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/ReadingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadingSession>>> GetReadingSessions()
        {
            return await _context.ReadingSessions.ToListAsync();
        }

        // GET: api/ReadingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadingSession>> GetReadingSession(int id)
        {
            var readingSession = await _context.ReadingSessions.FindAsync(id);

            if (readingSession == null)
            {
                return NotFound();
            }

            return readingSession;
        }

        // PUT: api/ReadingSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReadingSession(int id, ReadingSession readingSession)
        {
            if (id != readingSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(readingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingSessionExists(id))
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

        // POST: api/ReadingSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReadingSession>> PostReadingSession(ReadingSession readingSession)
        {
            _context.ReadingSessions.Add(readingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReadingSession", new { id = readingSession.Id }, readingSession);
        }

        // DELETE: api/ReadingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingSession(int id)
        {
            var readingSession = await _context.ReadingSessions.FindAsync(id);
            if (readingSession == null)
            {
                return NotFound();
            }

            _context.ReadingSessions.Remove(readingSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReadingSessionExists(int id)
        {
            return _context.ReadingSessions.Any(e => e.Id == id);
        }
    }
}
