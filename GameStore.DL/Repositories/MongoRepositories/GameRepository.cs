using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GameStore.DL.Interfaces;
using GameStore.Models.Configurations;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories.MongoRepositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IMongoCollection<Game> _games;
        private readonly ILogger<GameRepository> _logger;

        public GameRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<GameRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _games = database.GetCollection<Game>(
                $"{nameof(Game)}s");
        }

        public List<Game> GetAllGames()
        {
           return _games.Find(game => true).ToList();
        }

        public void AddGame(Game game)
        {
            if (game == null)
            {
                _logger.LogError("Game is null");
                return;
            }

            try
            {
                game.Id = Guid.NewGuid().ToString();

                _games.InsertOne(game);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding game {e.Message}-{e.StackTrace}");
            }
           
        }

        public Game? GetGameById(string id)
        {
            if(string.IsNullOrEmpty(id)) return null;

            return _games.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
