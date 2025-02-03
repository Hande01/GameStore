using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.BL.Services
{
    internal class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;
        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public void Add(Developer developer)
        {
            _developerRepository.AddDeveloper(developer);
        }
    }
}
