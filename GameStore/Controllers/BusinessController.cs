using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IGameBlService _gameService;
        private readonly IDeveloperService _developerService;

        public BusinessController(IGameBlService gameService, IDeveloperService developerService)
        {
            _gameService = gameService;
            _developerService = developerService;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllGameWithDetails")]
        public IActionResult GetAllGameWithDetails()
        {
            var result = _gameService.GetDetailedGames();

            if (result == null || result.Count == 0)
            {
                return NotFound("No games found");
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddDeveloper")]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            _developerService.Add(developer);

            return Ok();
        }

    }
}
