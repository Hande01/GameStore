using GameStore.Models.DTO;

namespace GameStore.DL.Interfaces
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        void AddGame(Game game);
        Game? GetGameById(string id);

        //void UpdateGame(Game game);
        //void DeleteGame(int id);
    }
}
