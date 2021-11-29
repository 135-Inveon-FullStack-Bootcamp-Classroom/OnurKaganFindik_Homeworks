using FootballManagerApi.Data;
using FootballManagerApi.ServiceAbstracts;
using System.Threading.Tasks;

namespace FootballManagerApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ITeamService teamService, IFootballerService footballerService, ICoachService coachService, ApplicationDbContext dbContext, ITacticService tacticService, IManagementPositionService managementPositionService, IManagerService managerService)
        {
            _dbContext = dbContext;
            this.FootballerService = footballerService;
            this.CoachService = coachService;
            this.TeamService = teamService;
            this.TacticService = tacticService;
            this.ManagementPositionService = managementPositionService;
            this.ManagerService = managerService;
        }

        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        public ICoachService CoachService { get; set; }
        public ITacticService TacticService { get; set; }
        public IManagementPositionService ManagementPositionService { get; set; }
        public IManagerService ManagerService { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
