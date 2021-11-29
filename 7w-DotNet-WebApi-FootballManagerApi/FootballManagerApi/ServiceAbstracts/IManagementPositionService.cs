using FootballManagerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApi.ServiceAbstracts
{
    public interface IManagementPositionService
    {
        public Task<IEnumerable<ManagementPosition>> GetAllAsync();
        public Task<ManagementPosition> GetAsync(int id);
        public Task UpdateAsync(int id, ManagementPosition managementPosition);
        public Task<ManagementPosition> CreateAsync(ManagementPosition managementPosition);
        public Task DeleteAsync(int id);
    }
}