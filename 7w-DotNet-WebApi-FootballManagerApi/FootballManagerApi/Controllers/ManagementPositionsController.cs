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
    public class ManagementPositionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagementPositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ManagementPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementPosition>>> GetManagementPositions()
        {
            var managementPosition = await _unitOfWork.ManagementPositionService.GetAllAsync();
            return Ok(managementPosition);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementPosition>> GetManagementPosition(int id)
        {
            var managementPosition = await _unitOfWork.ManagementPositionService.GetAsync(id);
            return Ok(managementPosition);
        }

        // PUT: api/ManagementPositions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagementPosition(int id, ManagementPosition managementPosition)
        {
            await _unitOfWork.ManagementPositionService.UpdateAsync(id, managementPosition);
            return NoContent();
        }

        // POST: api/ManagementPositions
        [HttpPost]
        public async Task<ActionResult<ManagementPosition>> PostManagementPosition(ManagementPosition managementPosition)
        {
            var createdManagementPosition = await _unitOfWork.ManagementPositionService.CreateAsync(managementPosition);
            return Ok(createdManagementPosition);
        }

        // DELETE: api/ManagementPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagementPosition(int id)
        {
            await _unitOfWork.ManagementPositionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
