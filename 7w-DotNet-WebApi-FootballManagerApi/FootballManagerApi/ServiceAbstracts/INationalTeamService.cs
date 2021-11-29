using FootballManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceAbstracts
{
    public interface INationalTeamService
    {
        public Task<IEnumerable<NationalTeam>> GetAllAsync();
        public Task<NationalTeam> GetAsync(int id);
        public Task UpdateAsync(int id, NationalTeam nationalTeam);
        public Task<NationalTeam> CreateAsync(NationalTeam nationalTeam);
        public Task DeleteAsync(int id);
    }
}