using GameStore.Models.Views;

namespace GameStore.BL.Interfaces
{
    public interface IGameBlService
    {
        List<GameView> GetDetailedGames();
    }
}
