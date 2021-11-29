using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FootballManagerApi.Data;
using FootballManagerApi.Entities;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementPositionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManagementPositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManagementPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementPosition>>> GetManagementPositions()
        {
            return await _context.ManagementPositions.ToListAsync();
        }

        // GET: api/ManagementPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementPosition>> GetManagementPosition(int id)
        {
            var managementPosition = await _context.ManagementPositions.FindAsync(id);

            if (managementPosition == null)
            {
                return NotFound();
            }

            return managementPosition;
        }

        // PUT: api/ManagementPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagementPosition(int id, ManagementPosition managementPosition)
        {
            if (id != managementPosition.Id)
            {
                return BadRequest();
            }

            _context.Entry(managementPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementPositionExists(id))
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

        // POST: api/ManagementPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagementPosition>> PostManagementPosition(ManagementPosition managementPosition)
        {
            _context.ManagementPositions.Add(managementPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagementPosition", new { id = managementPosition.Id }, managementPosition);
        }

        // DELETE: api/ManagementPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagementPosition(int id)
        {
            var managementPosition = await _context.ManagementPositions.FindAsync(id);
            if (managementPosition == null)
            {
                return NotFound();
            }

            _context.ManagementPositions.Remove(managementPosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagementPositionExists(int id)
        {
            return _context.ManagementPositions.Any(e => e.Id == id);
        }
    }
}
