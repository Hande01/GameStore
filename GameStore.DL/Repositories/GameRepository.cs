using GameStore.DL.StaticDB;
using GameStore.Models.DTO;

namespace GameStore.DL.Repositories
{
    //[Obsolete]
    //internal class GameStaticRepository
    //{
    //    public List<Game> GetAllGames()
    //    {
    //        return InMemoryDb.Games;
    //    }

    //    public void AddGame(Game game)
    //    {
    //        if (game == null) return;

    //        game.Id = Guid.NewGuid().ToString();
    //        InMemoryDb.Games.Add(game);
    //    }

    //    /// <summary>
    //    /// Get game by id
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public Game? GetGameById(string id)
    //    {
    //        return InMemoryDb.Games
    //            .FirstOrDefault(m => m.Id == id);
    //    }
    //}
}
