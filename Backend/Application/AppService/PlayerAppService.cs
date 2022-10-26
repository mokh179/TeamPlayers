using Common.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppService
{
    public class PlayerAppService : BaseAppservice, IPlayerAppService
    {
        private IPlayerMapper _playerMapper;
        public PlayerAppService(IUnitOfWork Theunitofwork,IPlayerMapper playerMapper) : base(Theunitofwork)
        {
            _playerMapper = playerMapper;
        }

        public async Task<APIResult> Create(PlayerDTO player)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                var playerobj = _playerMapper.Map(player);
               
                await _Theunitofwork.Players.AddOne(playerobj);
                if (_Theunitofwork.complete() > default(int))
                    result.TypeMessage = Common.Enums.typeMessage.Ok; result.Message = "Added Sucessfully";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public APIResult Delete(PlayerDTO player)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                if (player != null)
                {
                    _Theunitofwork.Players.Delete(_playerMapper.Map(player));
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

        public APIResult EditPlayer(PlayerDTO book)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                _Theunitofwork.Players.Update(_playerMapper.Map(book));
                if (_Theunitofwork.complete() > default(int))
                    result.TypeMessage = Common.Enums.typeMessage.Ok; result.Message = "Updated Sucessfully";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public async Task<List<PlayerDTO>> GetAllPlayers()
        {
            List<PlayerDTO> PlayersDTOs = new List<PlayerDTO>();
            try
            {
                var PlayersList = await _Theunitofwork.Players.getAll(new []{ "Team","Country"});
                foreach (var item in PlayersList)
                {
                    PlayersDTOs.Add(_playerMapper.Map(item));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return PlayersDTOs;
        }

        public async Task<PlayerDTO> GetbyId(int id)
        {
            PlayerDTO player = new PlayerDTO();
            try
            {
                var playerobj = await _Theunitofwork.Players.find(x=>x.playerId==id, new[] { "Team", "Country" });
                player = _playerMapper.Map(playerobj);
               
            }
            catch (Exception)
            {

                throw;
            }
            return player;
        }
    }
}
