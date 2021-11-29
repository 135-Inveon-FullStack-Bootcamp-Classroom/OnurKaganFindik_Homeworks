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
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        public TeamService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<IEnumerable<Team>> GetAllWithFootballersAsync()
        {
            return await _context.Teams.Include(p => p.Footballers).ToListAsync();

            //var query = from team in _context.Teams
            //            join footballer in _context.Footballers on team.Id equals footballer.Team.Id into f
            //            from footballer in f.DefaultIfEmpty()
            //            select new Team()
            //            {
            //                Name = team.Name,
            //                Footballers = new List<Footballer>()
            //                {
            //                    new Footballer() {
            //                        Name = footballer.Name
            //                    }
            //                }
            //            };

            //var list = await query.ToListAsync();

            //return list;
        }

        public async Task<Team> GetAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return team;
        }

        public async Task UpdateAsync(int id, Team team)
        {
            if (id != team.Id)
            {
                throw new Exception("Idler Uyuşmadı");
            }
            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    throw new Exception($"Id'si '{id}' olan takım bulunamadı");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Team> CreateAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team == null)
            {
                throw new Exception("Takım Bulunamadı");
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
