using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamPlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryAppService _countryAppService;
        public CountryController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _countryAppService.GetAllCountries());
        }
    }
}
