using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.IAppService
{
    public interface ITeamAppService
    {
        public Task<List<TeamDTO>> GetAllTeams();
        public Task<TeamDTO> GetbyId(int id);
        public APIResult EditTeam(TeamDTO team);
        public Task<APIResult> Create(TeamDTO team);
        public APIResult Delete(int id);
    }
}
