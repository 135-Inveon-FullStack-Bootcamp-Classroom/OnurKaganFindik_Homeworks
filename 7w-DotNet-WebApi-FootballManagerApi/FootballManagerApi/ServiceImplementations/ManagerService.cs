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
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _context;
        public ManagerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Manager> CreateAsync(Manager manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            return manager;
        }

        public async Task DeleteAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                throw new Exception("Manager Bulunamadı");
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager> GetAsync(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            return manager;
        }

        public async Task UpdateAsync(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                throw new Exception("Idler Uyuşmadı");
            }
            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
                {
                    throw new Exception($"Id'si '{id}' olan Manager bulunamadı");
                }
                else
                {
                    throw;
                }
            }
        }
        private bool ManagerExists(int id)
        {
            return _context.Managers.Any(e => e.Id == id);
        }
    }
}