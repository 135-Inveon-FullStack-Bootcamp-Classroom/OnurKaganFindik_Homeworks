using FootballManagerApi.Entities;
using FootballManagerApi.ServiceAbstracts;
using FootballManagerApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FootballersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Footballers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            var footballer = await _unitOfWork.TeamService.GetAllWithFootballersAsync();
            return Ok(footballer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetFootballer(int id)
        {
            var footballers = await _unitOfWork.FootballerService.GetAllAsync();
            return Ok(footballers);
        }

        // PUT: api/Footballers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballer(int id, Footballer footballer)
        {
            await _unitOfWork.FootballerService.UpdateAsync(id, footballer);
            return NoContent();
        }

        // POST: api/Footballers
        [HttpPost]
        public async Task<ActionResult<Footballer>> PostFootballer(Footballer footballer)
        {
            var createdFootballer = await _unitOfWork.FootballerService.CreateAsync(footballer);
            return Ok(createdFootballer);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballer(int id)
        {
            await _unitOfWork.FootballerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
