using FootballManagerApi.ServiceAbstracts;
using System.Threading.Tasks;

namespace FootballManagerApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        Task SaveChangesAsync();
    }
}
