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
    public class ManagersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> GetManagers()
        {
            var manager = await _unitOfWork.ManagerService.GetAllAsync();
            return Ok(manager);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _unitOfWork.ManagerService.GetAsync(id);
            return Ok(manager);
        }

        // PUT: api/Managers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(int id, Manager manager)
        {
            await _unitOfWork.ManagerService.UpdateAsync(id, manager);
            return NoContent();
        }

        // POST: api/Managers
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(Manager manager)
        {
            var createdManager = await _unitOfWork.ManagerService.CreateAsync(manager);
            return Ok(createdManager);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            await _unitOfWork.ManagerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
