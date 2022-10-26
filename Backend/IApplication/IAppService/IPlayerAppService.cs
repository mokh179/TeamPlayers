using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.IAppService
{
    public interface IPlayerAppService
    {
        public Task<List<PlayerDTO>> GetAllPlayers();
        public Task<PlayerDTO> GetbyId(int id);
        public APIResult EditBook(PlayerDTO player);
        public Task<APIResult> Create(PlayerDTO player);
        public APIResult Delete(int id);
    }
}
