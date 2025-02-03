using Moq;
using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameService.Tests
{
    public class GameBlServiceTests
    {
        private Mock<IGameService> _gameServiceMock;
        private Mock<IDeveloperRepository> _developerRepositoryMock;

        public GameBlServiceTests()
        {
            _gameServiceMock = new Mock<IGameService>();
            _developerRepositoryMock = new Mock<IDeveloperRepository>();
        }

        private List<Game> _games = new List<Game>
        {
            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Game 1",
                Year = 2024,
                Developers = ["Developer 1", "Developer 2"]
            },
            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Game 2",
                Year = 2025,
                Developers = ["Developer 3", "Developer 4"]
            }
        }; 

        private List<Developer> _developers = new List<Developer>
        {
            new Developer()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Developer 1"
            },
            new Developer()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Developer 2"
            },
            new Developer()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Developer 3"
            },
            new Developer()
            {
                Id = "9badefdc-0714-4581-80ae-161cd0a5abbe",
                Name = "Developer 4"
            }
        };

        [Fact]
        public void GetDetailedGames_Ok()
        {
            //setup
            var expectedCount = 2;

            _gameServiceMock
                .Setup(x => x.GetAllGames())
                .Returns(_games);
            _developerRepositoryMock.Setup(x => 
                    x.GetById(It.IsAny<string>()))
                .Returns((string id) =>
                    _developers.FirstOrDefault(x => x.Id == id));

            //inject
            var gameBlService = new GameBlService(
                _gameServiceMock.Object,
                _developerRepositoryMock.Object);

            //Act
            var result =
                gameBlService.GetDetailedGames();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

    }
}
