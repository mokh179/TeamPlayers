using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.IMapper
{
    public interface ITeamMapper
    {
        
        public TeamDTO Map(Team team);
        public Team Map(TeamDTO team);
    }
}
