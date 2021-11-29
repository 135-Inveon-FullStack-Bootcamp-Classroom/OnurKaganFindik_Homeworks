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
    public class FootballerService : IFootballerService
    {
        private readonly ApplicationDbContext _context;
        public FootballerService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Footballer>> GetAllAsync()
        {
            return await _context.Footballers.ToListAsync();
        }


        public async Task<Footballer> GetAsync(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);
            return footballer;
        }

        public async Task UpdateAsync(int id, Footballer footballer)
        {
            if (id != footballer.Id)
            {
                throw new Exception("Idler Uyuşmadı");
            }
            _context.Entry(footballer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballerExists(id))
                {
                    throw new Exception($"Id'si '{id}' olan Futbolcu bulunamadı");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Footballer> CreateAsync(Footballer footballer)
        {
            _context.Footballers.Add(footballer);
            await _context.SaveChangesAsync();

            return footballer;
        }

        public async Task DeleteAsync(int id)
        {
            var footballer = await _context.Footballers.FindAsync(id);

            if (footballer == null)
            {
                throw new Exception("Futbolcu Bulunamadı");
            }

            _context.Footballers.Remove(footballer);
            await _context.SaveChangesAsync();
        }

        private bool FootballerExists(int id)
        {
            return _context.Footballers.Any(e => e.Id == id);
        }
    }
}
