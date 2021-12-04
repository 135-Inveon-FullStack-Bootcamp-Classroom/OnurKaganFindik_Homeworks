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
    public class PositionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            var positions = await _unitOfWork.PositionService.GetAllAsync();
            return Ok(positions);
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
            var position = await _unitOfWork.PositionService.GetAsync(id);
            return Ok(position);
        }

        // PUT: api/Positions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(int id, Position position)
        {
            await _unitOfWork.PositionService.UpdateAsync(id, position);
            return NoContent();
        }

        // POST: api/Positions
        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition(Position position)
        {
            var createdPosition = await _unitOfWork.PositionService.CreateAsync(position);
            return Ok(createdPosition);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            await _unitOfWork.PositionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
