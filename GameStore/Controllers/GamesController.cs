using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly ILogger<GamesController> _logger;

        public GamesController(
            IGameService gameService,
            IMapper mapper, 
            ILogger<GamesController> logger)
        {
            _gameService = gameService;
            _mapper = mapper;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _gameService.GetAllGames();

            if (result == null || result.Count == 0)
            {
                return NotFound("No games found");
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id can't be null or empty");
            }

            var result = _gameService.GetById(id);

            if (result == null)
            {
                return NotFound($"Game with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(AddGameRequest game)
        {
            try
            {
                var gameDto = _mapper.Map<Game>(game);

                if (gameDto == null)
                {
                    return BadRequest("Can't convert game to game DTO");
                }

                _gameService.AddGame(gameDto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error adding game with");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            //_gameService.Delete(id);


            return Ok();
        }
    }
}
