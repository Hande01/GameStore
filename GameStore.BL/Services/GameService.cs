using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDeveloperRepository _developerRepository;

        public GameService(IGameRepository gameRepository, IDeveloperRepository developerRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        public void AddGame(Game? game)
        {
            if (game is null) return;

            foreach (var gameDeveloper in game.Developers)
            {
                var developer = _developerRepository.GetById(gameDeveloper);

                if (developer is null)
                {
                    throw new Exception(
                        $"Developer with id {gameDeveloper} does not exist");
                }
            }

            _gameRepository.AddGame(game);
        }

        public Game? GetById(string id)
        {
            return _gameRepository.GetGameById(id);
        }
    }
}
