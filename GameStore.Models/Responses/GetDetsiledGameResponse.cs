using GameStore.Models.DTO;

namespace GameStore.Models.Responses
{
    public class GetDetailedGameResponse
    {
        public Game Game { get; set; }

        public List<Developer> Developers { get; set; }
    }
}
