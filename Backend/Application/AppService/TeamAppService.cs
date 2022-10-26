using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppService
{
    public class TeamAppService : BaseAppservice, ITeamAppService
    {
        private ITeamMapper _teamMapper;

        public TeamAppService(IUnitOfWork Theunitofwork, ITeamMapper teamMapper) : base(Theunitofwork)
        {
            _teamMapper = teamMapper;
        }

        public async Task<APIResult> Create(TeamDTO team)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                var teamobj = _teamMapper.Map(team);

                await _Theunitofwork.Teams.AddOne(teamobj);
                if (_Theunitofwork.complete() > default(int))
                    result.TypeMessage = Common.Enums.typeMessage.Ok; result.Message = "Added Sucessfully";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public APIResult Delete(int id)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                var obj = _Theunitofwork.Teams.GetByID(id).Result;
                if (obj != null)
                {
                    _Theunitofwork.Teams.Delete(obj);
                    if (_Theunitofwork.complete() > default(int))
                        result.TypeMessage = Common.Enums.typeMessage.Ok; result.Message = "Deleted Sucessfully";

                }

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public APIResult EditTeam(TeamDTO team)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                _Theunitofwork.Teams.Update(_teamMapper.Map(team));
                if (_Theunitofwork.complete() > default(int))
                    result.TypeMessage = Common.Enums.typeMessage.Ok; result.Message = "Updated Sucessfully";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<List<TeamDTO>> GetAllTeams()
        {
            List<TeamDTO> TeamsDTOs = new List<TeamDTO>();
            try
            {
                var TeamsList = await _Theunitofwork.Teams.getAll();
                foreach (var item in TeamsList)
                {
                    TeamsDTOs.Add(_teamMapper.Map(item));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return TeamsDTOs;
        }

        public async Task<TeamDTO> GetbyId(int id)
        {
            TeamDTO team = new TeamDTO();
            try
            {
                var teamobj = await _Theunitofwork.Teams.GetByID(id);
                team = _teamMapper.Map(teamobj);

            }
            catch (Exception)
            {

                throw;
            }
            return team;
        }
    }
}
