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
        public async Task<ActionResult<IEnumerable<SavePointNoteDTO>>> GetSavePointNotes()
        {
            // TODO: Return the Game Object with the SavePointNote
            return await 
                _context.SavePointNotes
                .Select(x => SavePointNoteToDTO(x))
                .ToListAsync();
        }

        // GET: api/SavePointNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavePointNoteDTO>> GetSavePointNote(int id)
        {
            var savePointNote = await _context.SavePointNotes.FindAsync(id);

            if (savePointNote == null)
            {
                return NotFound();
            }

            return SavePointNoteToDTO(savePointNote);
        }

        // PUT: api/SavePointNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavePointNote(int id, SavePointNoteDTO savePointNoteDTO)
        {
            if (id != savePointNoteDTO.SavePointNoteId)
            {
                return BadRequest();
            }

            var savePointNote = await _context.SavePointNotes.FindAsync(id);
            if (savePointNote == null)
            {
                return NotFound();
            }

            savePointNote.Note = savePointNoteDTO.Note;
            savePointNote.NoteDate = savePointNoteDTO.NoteDate;
            savePointNote.SavePointGameId = savePointNoteDTO.SavePointGameId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SavePointNoteExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/SavePointNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavePointNote>> PostSavePointNote(SavePointNoteDTO savePointNoteDTO)
        {
            var savePointNote = new SavePointNote
            {
                Note = savePointNoteDTO.Note,
                NoteDate = savePointNoteDTO.NoteDate,
                SavePointGameId = savePointNoteDTO.SavePointGameId
            };
            _context.SavePointNotes.Add(savePointNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSavePointNote), 
                new { id = savePointNoteDTO.SavePointNoteId }, 
                SavePointNoteToDTO(savePointNote));
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

        private static SavePointNoteDTO SavePointNoteToDTO(SavePointNote savePointNote) =>
            new SavePointNoteDTO
            {
                SavePointNoteId = savePointNote.SavePointNoteId,
                Note = savePointNote.Note,
                NoteDate = savePointNote.NoteDate,
                SavePointGameId = savePointNote.SavePointGameId
            };
    }
}
