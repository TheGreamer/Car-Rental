using CarRental.Business.Abstract;
using CarRental.Core.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;

namespace CarRental.Business.Concrete
{
    public class TeamMemberService : CoreService<TeamMember, ITeamMemberDal>, ITeamMemberService
    {
        public TeamMemberService(ITeamMemberDal teamMemberDal) : base(teamMemberDal)
        {
        }
    }
}