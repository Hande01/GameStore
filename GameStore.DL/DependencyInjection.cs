using Microsoft.Extensions.DependencyInjection;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories;
using GameStore.DL.Repositories.MongoRepositories;

namespace GameStore.DL
{
    public static class DependencyInjection
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<IGameRepository, GameRepository>()
                .AddSingleton<IDeveloperRepository, DeveloperRepository>();
        }
    }
}
