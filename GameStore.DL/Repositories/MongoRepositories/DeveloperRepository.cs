using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GameStore.DL.Interfaces;
using GameStore.Models.Configurations;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories.MongoRepositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly IMongoCollection<Developer> _developers;
        private readonly ILogger<DeveloperRepository> _logger;

        public DeveloperRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<DeveloperRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _developers = database.GetCollection<Developer>(
                $"{nameof(Developer)}s");
        }

        public void AddDeveloper(Developer developer)
        {
            developer.Id = System.Guid.NewGuid().ToString();
            _developers.InsertOne(developer);
        }

        public void AddGame(Developer game)
        {
            if (game == null)
            {
                _logger.LogError("Game is null");
                return;
            }

            try
            {
                game.Id = Guid.NewGuid().ToString();

                _developers.InsertOne(game);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding game {e.Message}-{e.StackTrace}");
            }
           
        }


        public IEnumerable<Developer> GetDevelopersByIds(IEnumerable<string> developersIds)
        {
            var result = _developers.Find(developer => developersIds.Contains(developer.Id)).ToList();
            return result;
        }

        public Developer? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _developers.Find(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}
