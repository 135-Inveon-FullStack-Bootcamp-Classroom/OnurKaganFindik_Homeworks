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
    public class NationalTeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NationalTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NationalTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NationalTeam>>> GetNationalTeams()
        {
            return await _context.NationalTeams.ToListAsync();
        }

        // GET: api/NationalTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NationalTeam>> GetNationalTeam(int id)
        {
            var nationalTeam = await _context.NationalTeams.FindAsync(id);

            if (nationalTeam == null)
            {
                return NotFound();
            }

            return nationalTeam;
        }

        // PUT: api/NationalTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationalTeam(int id, NationalTeam nationalTeam)
        {
            if (id != nationalTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(nationalTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalTeamExists(id))
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

        // POST: api/NationalTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NationalTeam>> PostNationalTeam(NationalTeam nationalTeam)
        {
            _context.NationalTeams.Add(nationalTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNationalTeam", new { id = nationalTeam.Id }, nationalTeam);
        }

        // DELETE: api/NationalTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationalTeam(int id)
        {
            var nationalTeam = await _context.NationalTeams.FindAsync(id);
            if (nationalTeam == null)
            {
                return NotFound();
            }

            _context.NationalTeams.Remove(nationalTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NationalTeamExists(int id)
        {
            return _context.NationalTeams.Any(e => e.Id == id);
        }
    }
}
