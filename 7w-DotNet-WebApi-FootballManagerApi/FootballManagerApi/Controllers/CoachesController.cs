using FootballManagerApi.Data;
using FootballManagerApi.Entities;
using FootballManagerApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoachesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches(int id)
        {
            var coach = await _unitOfWork.CoachService.GetAsync(id);
            return Ok(coach);
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coaches = await _unitOfWork.CoachService.GetAsync(id);
            return Ok(coaches);
        }

        // PUT: api/Coaches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            await _unitOfWork.CoachService.UpdateAsync(id, coach);
            return NoContent();
        }

        // POST: api/Coaches
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            var createdCoach = await _unitOfWork.CoachService.CreateAsync(coach);
            //await _unitOfWork.SaveChangesAsync();
            return Ok(createdCoach);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            await _unitOfWork.CoachService.DeleteAsync(id);
            return NoContent();
        }
    }
}
