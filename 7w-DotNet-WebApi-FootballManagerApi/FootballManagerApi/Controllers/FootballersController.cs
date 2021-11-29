using FootballManagerApi.Entities;
using FootballManagerApi.ServiceAbstracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballersController : ControllerBase
    {
        private readonly IFootballerService _footballerService;

        public FootballersController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }

        // GET: api/Footballers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footballer>>> GetFootballers()
        {
            var footballer = await _footballerService.GetAllAsync();
            return Ok(footballer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetFootballer(int id)
        {
            var footballer = await _footballerService.GetAsync(id);
            return Ok(footballer);
        }

        // PUT: api/Footballers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootballer(int id, Footballer footballer)
        {
            await _footballerService.UpdateAsync(id, footballer);
            return NoContent();
        }

        // POST: api/Footballers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Footballer>> PostFootballer(Footballer footballer)
        {
            var createdFootballer = await _footballerService.CreateAsync(footballer);
            return Ok(createdFootballer);
        }

        // DELETE: api/Footballers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootballer(int id)
        {
            await _footballerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
