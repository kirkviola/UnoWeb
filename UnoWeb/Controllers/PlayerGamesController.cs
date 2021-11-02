using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnoWeb.Models;

namespace UnoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerGamesController : ControllerBase
    {
        private readonly UnoDbContext _context;

        public PlayerGamesController(UnoDbContext context)
        {
            _context = context;
        }

        // GET: api/PlayerGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGame>>> GetPlayerGames()
        {
            return await _context.PlayerGames.ToListAsync();
        }

        // GET: api/PlayerGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerGame>> GetPlayerGame(int id)
        {
            var playerGame = await _context.PlayerGames.FindAsync(id);

            if (playerGame == null)
            {
                return NotFound();
            }

            return playerGame;
        }

        // PUT: api/PlayerGames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerGame(int id, PlayerGame playerGame)
        {
            if (id != playerGame.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerGameExists(id))
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

        // POST: api/PlayerGames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerGame>> PostPlayerGame(PlayerGame playerGame)
        {
            _context.PlayerGames.Add(playerGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerGame", new { id = playerGame.Id }, playerGame);
        }

        // DELETE: api/PlayerGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerGame(int id)
        {
            var playerGame = await _context.PlayerGames.FindAsync(id);
            if (playerGame == null)
            {
                return NotFound();
            }

            _context.PlayerGames.Remove(playerGame);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerGameExists(int id)
        {
            return _context.PlayerGames.Any(e => e.Id == id);
        }
    }
}
