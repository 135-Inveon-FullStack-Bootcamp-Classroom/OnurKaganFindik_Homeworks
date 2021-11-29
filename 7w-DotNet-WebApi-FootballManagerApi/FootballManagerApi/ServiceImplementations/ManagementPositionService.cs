using FootballManagerApi.Data;
using FootballManagerApi.Entities;
using FootballManagerApi.ServiceAbstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceImplementations
{
    public class ManagementPositionService : IManagementPositionService
    {

        private readonly ApplicationDbContext _context;
        public ManagementPositionService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ManagementPosition> CreateAsync(ManagementPosition managementPosition)
        {
            _context.ManagementPositions.Add(managementPosition);
            await _context.SaveChangesAsync();

            return managementPosition;
        }

        public async Task DeleteAsync(int id)
        {
            var managementPosition = await _context.ManagementPositions.FindAsync(id);

            if (managementPosition == null)
            {
                throw new Exception("Yönetici Pozisyonu Bulunamadı");
            }

            _context.ManagementPositions.Remove(managementPosition);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ManagementPosition>> GetAllAsync()
        {
            return await _context.ManagementPositions.ToListAsync();
        }

        public async Task<ManagementPosition> GetAsync(int id)
        {
            var managementPosition = await _context.ManagementPositions.FindAsync(id);
            return managementPosition;
        }

        public async Task UpdateAsync(int id, ManagementPosition managementPosition)
        {
            if (id != managementPosition.Id)
            {
                throw new Exception("Idler Uyuşmadı");
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
                    throw new Exception($"Id'si '{id}' olan Yönetici Pozisyonu bulunamadı");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ManagementPositionExists(int id)
        {
            return _context.ManagementPositions.Any(e => e.Id == id);
        }
    }
}