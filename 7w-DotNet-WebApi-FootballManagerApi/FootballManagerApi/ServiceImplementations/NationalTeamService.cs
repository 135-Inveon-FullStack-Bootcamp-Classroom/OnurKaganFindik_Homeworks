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
    public class NationalTeamService : INationalTeamService
    {
        private readonly ApplicationDbContext _context;
        public NationalTeamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NationalTeam> CreateAsync(NationalTeam nationalTeam)
        {
            _context.NationalTeams.Add(nationalTeam);
            await _context.SaveChangesAsync();

            return nationalTeam;
        }

        public async Task DeleteAsync(int id)
        {

            var nationalTeam = await _context.NationalTeams.FindAsync(id);

            if (nationalTeam == null)
            {
                throw new Exception("Milli Takım Bulunamadı");
            }

            _context.NationalTeams.Remove(nationalTeam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NationalTeam>> GetAllAsync()
        {
            return await _context.NationalTeams.ToListAsync();
        }

        public async Task<NationalTeam> GetAsync(int id)
        {
            var nationalTeam = await _context.NationalTeams.FindAsync(id);
            return nationalTeam;
        }

        public async Task UpdateAsync(int id, NationalTeam nationalTeam)
        {
            if (id != nationalTeam.Id)
            {
                throw new Exception("Idler Uyuşmadı");
            }
            _context.Entry(nationalTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalTeamExists(id))
                {
                    throw new Exception($"Id'si '{id}' olan Milli Takım bulunamadı");
                }
                else
                {
                    throw;
                }
            }
        }

        private bool NationalTeamExists(int id)
        {
            return _context.NationalTeams.Any(e => e.Id == id);
        }
    }
}