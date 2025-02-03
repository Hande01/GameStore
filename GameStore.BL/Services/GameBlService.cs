using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using GameStore.Models.Views;

namespace GameStore.BL.Services
{
    internal class GameBlService : IGameBlService
    {
        private readonly IGameService _gameService;
        private readonly IDeveloperRepository _developerRepository;

        public GameBlService(
            IGameService gameService,
            IDeveloperRepository developerRepository)
        {
            _gameService = gameService;
            _developerRepository = developerRepository;
        }

        public List<GameView> GetDetailedGames()
        {
            var result = new List<GameView>();

            var games = _gameService.GetAllGames();

            foreach (var game in games)
            {
                var gameView = new GameView
                {
                    GameId = game.Id,
                    GameTitle = game.Title,
                    GameYear = game.Year,
                    Developers = _developerRepository.GetDevelopersByIds(game.Developers)
                };

                result.Add(gameView);
            }

            return result;
        }
    }
}
