using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SavePointAPI.Models;

namespace SavePointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavePointNotesController : ControllerBase
    {
        private readonly SavePointContext _context;

        public SavePointNotesController(SavePointContext context)
        {
            _context = context;
        }

        // GET: api/SavePointNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavePointNote>>> GetSavePointNotes()
        {
            return await _context.SavePointNotes.ToListAsync();
        }

        // GET: api/SavePointNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavePointNote>> GetSavePointNote(int id)
        {
            var savePointNote = await _context.SavePointNotes.FindAsync(id);

            if (savePointNote == null)
            {
                return NotFound();
            }

            return savePointNote;
        }

        // PUT: api/SavePointNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavePointNote(int id, SavePointNote savePointNote)
        {
            if (id != savePointNote.SavePointNoteId)
            {
                return BadRequest();
            }

            _context.Entry(savePointNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavePointNoteExists(id))
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

        // POST: api/SavePointNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavePointNote>> PostSavePointNote(SavePointNote savePointNote)
        {
            _context.SavePointNotes.Add(savePointNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavePointNote", new { id = savePointNote.SavePointNoteId }, savePointNote);
        }

        // DELETE: api/SavePointNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavePointNote(int id)
        {
            var savePointNote = await _context.SavePointNotes.FindAsync(id);
            if (savePointNote == null)
            {
                return NotFound();
            }

            _context.SavePointNotes.Remove(savePointNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavePointNoteExists(int id)
        {
            return _context.SavePointNotes.Any(e => e.SavePointNoteId == id);
        }
    }
}
