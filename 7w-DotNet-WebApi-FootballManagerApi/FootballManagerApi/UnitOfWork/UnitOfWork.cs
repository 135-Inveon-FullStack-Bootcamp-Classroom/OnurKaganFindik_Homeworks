using FootballManagerApi.Data;
using FootballManagerApi.ServiceAbstracts;
using System.Threading.Tasks;

namespace FootballManagerApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ITeamService teamService, IFootballerService footballerService, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.FootballerService = footballerService;
            this.TeamService = teamService;
        }

        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
