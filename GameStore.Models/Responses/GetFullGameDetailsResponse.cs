using GameStore.Models.Views;

namespace GameStore.Models.Responses
{
    public class GetFullGameDetailsResponse
    {
        IEnumerable<GameView> Games { get; set; } = [];
    }
}
