using GameStore.Models.DTO;

namespace GameStore.BL.Interfaces
{
    public interface IGameService
    {
        List<Game> GetAllGames();

        void AddGame(Game game);

        Game? GetById(string id);
    }
}
