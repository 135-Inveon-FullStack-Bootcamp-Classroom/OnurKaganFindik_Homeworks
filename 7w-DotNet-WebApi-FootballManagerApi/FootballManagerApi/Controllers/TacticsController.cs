using FootballManagerApi.Data;
using FootballManagerApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacticsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TacticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tactics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tactic>>> GetTactics()
        {
            return await _context.Tactics.ToListAsync();
        }

        // GET: api/Tactics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tactic>> GetTactic(int id)
        {
            var tactic = await _context.Tactics.FindAsync(id);

            if (tactic == null)
            {
                return NotFound();
            }

            return tactic;
        }

        // PUT: api/Tactics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTactic(int id, Tactic tactic)
        {
            if (id != tactic.Id)
            {
                return BadRequest();
            }

            _context.Entry(tactic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacticExists(id))
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

        // POST: api/Tactics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tactic>> PostTactic(Tactic tactic)
        {
            _context.Tactics.Add(tactic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTactic", new { id = tactic.Id }, tactic);
        }

        // DELETE: api/Tactics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTactic(int id)
        {
            var tactic = await _context.Tactics.FindAsync(id);
            if (tactic == null)
            {
                return NotFound();
            }

            _context.Tactics.Remove(tactic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacticExists(int id)
        {
            return _context.Tactics.Any(e => e.Id == id);
        }
    }
}
