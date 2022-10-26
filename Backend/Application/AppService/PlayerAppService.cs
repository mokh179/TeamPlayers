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

        public APIResult Delete(int id)
        {
            APIResult result = new APIResult() { Message = "Error", TypeMessage = Common.Enums.typeMessage.Error };
            try
            {
                var obj = _Theunitofwork.Players.GetByID(id).Result;
                if (obj != null)
                {
                    _Theunitofwork.Players.Delete(obj);
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

        public APIResult EditBook(PlayerDTO book)
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
                var PlayersList = await _Theunitofwork.Players.getAll();
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
                var playerobj = await _Theunitofwork.Players.GetByID(id);
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
