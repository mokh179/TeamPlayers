using Common.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class PlayerMapper : IPlayerMapper
    {
        public PlayerDTO Map(Player player)
        {
            return new PlayerDTO() { playerId=player.playerId,playerName=player.playerName,dateofBirth=player.dateofBirth,teamId=player.teamId,countryId=player.countryId,teamName=player.Team.teamName,countryName=player.Country.countryName};
        }

        public Player Map(PlayerDTO player)
        {
            return new Player() { playerId = player.playerId, playerName = player.playerName, dateofBirth = player.dateofBirth, teamId = player.teamId, countryId = player.countryId };
        }
    }
}
