using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamteamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamAppService _team;
      
        public TeamController(ITeamAppService team)
        {
            _team=team;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _team.GetAllTeams());
        }
        [Authorize(Roles = "Admin"), HttpPost("AddTeam")]
        public async Task<IActionResult> Create(TeamDTO team)
        {
            if (!ModelState.IsValid)
                return BadRequest(team);
            return Ok(await _team.Create(team));
        }

        [Authorize(Roles = "Admin"), HttpGet("Getteam/{id}")]
        public async Task<IActionResult> Getteam(int id)
        {
            return Ok(await _team.GetbyId(id));
        }

        [Authorize(Roles = "Admin"), HttpPost("Editteam")]
        public IActionResult Edit(TeamDTO team)
        {
            if (team != null)
                return Ok(_team.EditTeam(team));
            return BadRequest(team);
        }

        [Authorize(Roles ="Admin"),HttpDelete("Deleteteam")]
        public IActionResult Delete(TeamDTO team)
        {
            if (ModelState.IsValid)
               return Ok(_team.Delete(team));
            return BadRequest();
        }
    }
}
