using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamPlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerAppService _player;
        public PlayerController(IPlayerAppService player)
        {
            _player= player;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _player.GetAllPlayers());
        }
        [Authorize,HttpPost("AddPlayer")]
        public async Task<IActionResult> Create(PlayerDTO player)
        {
            if (!ModelState.IsValid)
                return BadRequest(player);
            return Ok(await _player.Create(player));
        }

        [Authorize, HttpGet("Getplayer/{id}")]
        public async Task<IActionResult> Getplayer(int id)
        {
            return Ok(await _player.GetbyId(id));
        }

        [Authorize, HttpPost("EditPlayer")]
        public IActionResult Edit(PlayerDTO player)
        {
            if (player != null)
                return Ok(_player.EditPlayer(player));
            return BadRequest(player);
        }

        [Authorize, HttpPost("DeletePlayer")]
        public IActionResult Delete(PlayerDTO player)
        {
            if (!ModelState.IsValid)
                return Ok(_player.Delete(player));
            return BadRequest();
        }
    }
}
