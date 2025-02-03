using Mapster;
using GameStore.Models.DTO;
using GameStore.Models.Requests;

namespace GameStore.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Game, AddGameRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}
