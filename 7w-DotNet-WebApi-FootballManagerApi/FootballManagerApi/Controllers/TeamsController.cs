using FootballManagerApi.Entities;
using FootballManagerApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _unitOfWork.TeamService.GetAllWithFootballersAsync();
            return Ok(teams);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _unitOfWork.TeamService.GetAsync(id);
            return Ok(team);
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            await _unitOfWork.TeamService.UpdateAsync(id, team);
            return NoContent();
        }

        [HttpPost("{id}/add-footballer")]
        public async Task<IActionResult> AddFootballer(int id, [FromBody] Footballer footballer)
        {
            footballer.Team = await _unitOfWork.TeamService.GetAsync(id);
            var createFootballer = await _unitOfWork.FootballerService.CreateAsync(footballer);

            return Ok(createFootballer);
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            var createdTeam = await _unitOfWork.TeamService.CreateAsync(team);
            //await _unitOfWork.SaveChangesAsync();
            return Ok(createdTeam);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _unitOfWork.TeamService.DeleteAsync(id);
            return NoContent();
        }
    }
}
