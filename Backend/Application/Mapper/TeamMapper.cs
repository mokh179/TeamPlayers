using Common.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    internal class TeamMapper : ITeamMapper
    {
        public TeamDTO Map(Team team)
        {
            return new TeamDTO() { teamId=team.teamId,coachName = team.coachName, foundedIn = team.foundedIn, nationality = team.nationality, teamName = team.teamName };
        }

        public Team Map(TeamDTO team)
        {
            return new Team() { coachName = team.coachName, foundedIn = team.foundedIn, nationality = team.nationality, teamName = team.teamName };
        }
    }
}
