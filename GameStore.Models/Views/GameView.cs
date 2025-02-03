using GameStore.Models.DTO;

namespace GameStore.Models.Views
{
    public class GameView
    {
        public string GameId { get; set; }

        public string GameTitle { get; set; } = string.Empty;

        public int GameYear { get; set; }

        public IEnumerable<Developer> Developers { get; set; } = [];
    }
}
