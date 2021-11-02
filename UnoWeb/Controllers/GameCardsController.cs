﻿using System;
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
    public class GameCardsController : ControllerBase
    {
        private readonly UnoDbContext _context;

        public GameCardsController(UnoDbContext context)
        {
            _context = context;
        }

        // GET: api/GameCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameCard>>> GetGameCards()
        {
            return await _context.GameCards.ToListAsync();
        }

        // GET: api/GameCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameCard>> GetGameCard(int id)
        {
            var gameCard = await _context.GameCards.FindAsync(id);

            if (gameCard == null)
            {
                return NotFound();
            }

            return gameCard;
        }

        // PUT: api/GameCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameCard(int id, GameCard gameCard)
        {
            if (id != gameCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCardExists(id))
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

        [HttpPut("draw/{gameid}")]
        public async Task<IActionResult> Draw(int gameid)
        {
            var game = await _context.Games.FindAsync(gameid);
            if (game == null)
            {
                return NotFound();
            }
            var playerid = game.ActiveId;
            var minSequence = await (from c in _context.GameCards orderby c.SequenceNumber select c).ToListAsync();
            var gamecard = minSequence[0];
            gamecard.SequenceNumber = null;
            gamecard.PlayerId = playerid;
            return await PutGameCard(gamecard.Id, gamecard);


        }

        [HttpPut("play/{gameid")]
        public async Task<IActionResult> Play(int gameid, GameCard card)
        {
            var game = await _context.Games.FindAsync(gameid);
                    if (game == null)
                    {
                        return NotFound();
                    }
            var playerid = game.ActiveId;
            if (card.PlayerId!=playerid)
            {
                return BadRequest();
            }

            card.PlayerId = null;
            card.IsPlayed = true;
            return await PutGameCard(card.Id, card);

        }

    // PUT: Shuffle cards in the deck
    [HttpPut("{id}/shuffle")]
        public async Task<ActionResult<List<GameCard>>> Shuffle(int id)
        {


            var cards = await (from gc in _context.GameCards
                               where gc.GameId == id
                               select gc).ToListAsync();

            var rand = new Random();
            var sequence = new List<int>();
            var num = 0;

            while (sequence.Count < cards.Count)
            {
                do
                {
                    num = rand.Next(1, cards.Count + 1);
                } while (sequence.Contains(num));
                {
                    sequence.Add(num);
                }
            }

            for (var idx = 0; idx < cards.Count; idx++)
            {
                cards[idx].SequenceNumber = sequence[idx];
            }

            return cards;
        }
        // POST: api/GameCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameCard>> PostGameCard(GameCard gameCard)
        {
            _context.GameCards.Add(gameCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameCard", new { id = gameCard.Id }, gameCard);
        }

        // DELETE: api/GameCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameCard(int id)
        {
            var gameCard = await _context.GameCards.FindAsync(id);
            if (gameCard == null)
            {
                return NotFound();
            }

            _context.GameCards.Remove(gameCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameCardExists(int id)
        {
            return _context.GameCards.Any(e => e.Id == id);
        }
    }
}
