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
    public class SavePointGamesController : ControllerBase
    {
        private readonly SavePointContext _context;

        public SavePointGamesController(SavePointContext context)
        {
            _context = context;
        }

        // GET: api/SavePointGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavePointGameDTO>>> GetSavePointGames()
        {
            // TODO: Return the list of notes associated with the game
            var savePointGames = await _context.SavePointGames.ToListAsync();
            var savePointGameDTOs = savePointGames.Select(SavePointGameToDTO);
            return Ok(savePointGameDTOs);
        }

        // GET: api/SavePointGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavePointGameDTO>> GetSavePointGame(int id)
        {
            var savePointGame = await _context.SavePointGames.FindAsync(id);

            if (savePointGame == null)
            {
                return NotFound();
            }

            return SavePointGameToDTO(savePointGame);
        }

        // PUT: api/SavePointGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavePointGame(int id, SavePointGameDTO savePointGameDTO)
        {
            if (id != savePointGameDTO.SavePointGameId)
            {
                return BadRequest();
            }

            var savePointGame = await _context.SavePointGames.FindAsync(id);
            if (savePointGame == null)
            {
                return NotFound();
            }

            savePointGame.GameName = savePointGameDTO.GameName;
            savePointGame.GameConsole = savePointGameDTO.GameConsole;
            savePointGame.GameGenre = savePointGameDTO.GameGenre;
            savePointGame.GameDeveloper = savePointGameDTO.GameDeveloper;
            savePointGame.GamePublisher = savePointGameDTO.GamePublisher;
            savePointGame.GameReleaseDate = savePointGameDTO.GameReleaseDate;
            savePointGame.GameDescription = savePointGameDTO.GameDescription;
            savePointGame.GameRating = savePointGameDTO.GameRating;
            savePointGame.GameImage = savePointGameDTO.GameImage;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SavePointGameExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/SavePointGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavePointGame>> PostSavePointGame(SavePointGameDTO savePointGame)
        {
            var Game = new SavePointGame
            {
                GameName = savePointGame.GameName,
                GameConsole = savePointGame.GameConsole,
                GameGenre = savePointGame.GameGenre,
                GameDeveloper = savePointGame.GameDeveloper,
                GamePublisher = savePointGame.GamePublisher,
                GameReleaseDate = savePointGame.GameReleaseDate,
                GameDescription = savePointGame.GameDescription,
            };
            _context.SavePointGames.Add(Game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostSavePointGame), new { id = savePointGame.SavePointGameId }, savePointGame);
        }

        // DELETE: api/SavePointGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavePointGame(int id)
        {
            var savePointGame = await _context.SavePointGames.FindAsync(id);
            if (savePointGame == null)
            {
                return NotFound();
            }

            _context.SavePointGames.Remove(savePointGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavePointGameExists(int id)
        {
            return _context.SavePointGames.Any(e => e.SavePointGameId == id);
        }

        private SavePointGameDTO SavePointGameToDTO(SavePointGame savePointGame) =>
            new SavePointGameDTO
            {
                SavePointGameId = savePointGame.SavePointGameId,
                GameName = savePointGame.GameName,
                GameConsole = savePointGame.GameConsole,
                GameGenre = savePointGame.GameGenre,
                GameDeveloper = savePointGame.GameDeveloper,
                GamePublisher = savePointGame.GamePublisher,
                GameReleaseDate = savePointGame.GameReleaseDate,
                GameDescription = savePointGame.GameDescription,
                GameRating = savePointGame.GameRating,
                GameImage = savePointGame.GameImage
            };
    }
}
